using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ConsomiTounsi.Models;
using ConsomiTounsiFront.Models;
using Newtonsoft.Json;

namespace ConsomiTounsi.Controllers
{
    public class DeliveryMenController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress;List<String> cl; User u=null;

        public DeliveryMenController()
        {
            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            u = TokenFixed.GetUser();

        }
        // GET: DeliveryMen
        public ActionResult Index()
        {
             var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/DeliveryMens").Result;
            if (response.IsSuccessStatusCode)
            {
                  var dm = response.Content.ReadAsAsync<IEnumerable<DeliveryMen>>().Result;
                    return View(dm);
                
                
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<DeliveryMen>());
            }
        }

        public ActionResult stats()
        {
             //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/stats").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<DataPoint>>().Result;
                List<DataPoint> dataPoints = new List<DataPoint>();
                ViewBag.DataPoints = JsonConvert.SerializeObject(dm);
                return View(dm);
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<DeliveryMen>());
            }
            
        }

        public ActionResult PlusProcheDeliveryMen(string lat)
        {
             //GET Method  
            var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/PlusProcheDeliveryMen").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<DeliveryMen>>().Result;
                return View( dm);
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<DeliveryMen>());
            }
        }

        public ActionResult Prime()
        {
            //GET Method  
            var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/prime").Result;
            if (response.IsSuccessStatusCode)
            {
                //  var dm = response.Content.ReadAsAsync<IEnumerable<delivery_men>>().Result;
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return HttpNotFound();
            }
        }

        // GET: DeliveryMen/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             //GET Method  
            var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/DeliveryMen?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<DeliveryMen>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // GET: DeliveryMen/Create
        public ActionResult Create()
        {
          //  ViewBag.id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: DeliveryMen/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "available,prime,id,latitude,longitude,email,username,actived,lat,lon")] DeliveryMen delivery_men)
        {
            delivery_men.latitude= double.Parse(delivery_men.lat, System.Globalization.CultureInfo.InvariantCulture);
            delivery_men.longitude = double.Parse(delivery_men.lon, System.Globalization.CultureInfo.InvariantCulture);
            
            var postTask = httpClient.PostAsJsonAsync<DeliveryMen>(baseAddress+"ConsomiTounsi/DeliveryMen", delivery_men);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new DeliveryMen());
        }

        // GET: DeliveryMen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           //GET Method  
            var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/DeliveryMen?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<DeliveryMen>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // POST: DeliveryMen/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "available,prime,id,latitude,longitude,email,username,actived,lat,lon")]  DeliveryMen delivery_men)
        {
            if (ModelState.IsValid)
            {
                delivery_men.latitude = double.Parse(delivery_men.lat, System.Globalization.CultureInfo.InvariantCulture);
                delivery_men.longitude = double.Parse(delivery_men.lon, System.Globalization.CultureInfo.InvariantCulture);
               
                var postTask = httpClient.PutAsJsonAsync<DeliveryMen>(baseAddress+"ConsomiTounsi/DeliveryMen/" + delivery_men.id, delivery_men);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(delivery_men);
        }

        // GET: DeliveryMen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ///GET Method  
            var response = httpClient.GetAsync(baseAddress+"ConsomiTounsi/Delivery/DeliveryMen?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<DeliveryMen>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View( dm);
            }

            return HttpNotFound();
        }

        // POST: DeliveryMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
          
            var postTask = httpClient.DeleteAsync(baseAddress+"ConsomiTounsi/DeliveryMen/" + id);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
