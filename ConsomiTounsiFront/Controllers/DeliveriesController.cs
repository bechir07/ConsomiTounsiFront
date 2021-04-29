using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using ConsomiTounsi.Models;
using ConsomiTounsiFront.Models;

namespace ConsomiTounsi.Controllers
{
    public class DeliveriesController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress;
        User u;
        public DeliveriesController()
        {
            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            u = TokenFixed.GetUser();
        }

        // GET: Deliveries
        public ActionResult Index()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/Deliveries").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<delivery>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<delivery>());
            }
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/Delivery?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<delivery>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.deliver_men_id = new SelectList(this.GetDeliveryMens(), "id", "username");
            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "id,adresse,date,frais,poids,state,deliver_men_id")] delivery delivery,int? idDeliveryMen)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<delivery>(baseAddress + "ConsomiTounsi/Delivery/newDelivery?id=" + delivery.deliver_men_id, delivery);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new delivery());
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/Delivery?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<delivery>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                ViewBag.deliver_men_id = new SelectList(this.GetDeliveryMens(), "id", "id");
                return View(dm);
            }

            return HttpNotFound();
        }

        // POST: Deliveries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "id,adresse,date,frais,poids,state,deliver_men_id")] delivery delivery,long? idDeliveryMen)
        {
            if (ModelState.IsValid)
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = httpClient.PutAsJsonAsync<delivery>(baseAddress + "ConsomiTounsi/Delivery/updateDelivery?id=" + idDeliveryMen, delivery);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/Delivery?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<delivery>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.DeleteAsync(baseAddress + "ConsomiTounsi/Deliveries/" + id);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       public IEnumerable<DeliveryMen> GetDeliveryMens()
        {
            //httpClient.BaseAddress = new Uri(baseAddress+"http://localhost:8082/ConsomiTounsi");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Delivery/DeliveryMens").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<DeliveryMen> dm = response.Content.ReadAsAsync<IEnumerable<DeliveryMen>>().Result;
                return dm;


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }
    }
}
