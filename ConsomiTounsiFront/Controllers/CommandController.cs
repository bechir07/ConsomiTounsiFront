using ConsomiTounsiFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace ConsomiTounsiFront.Controllers
{
    public class CommandController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();

        HttpClient httpClient;
        string baseAddress;

        public CommandController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJtb250YSIsImV4cCI6MTYxOTU3MTY2MSwiaWF0IjoxNjE5NTUzNjYxLCJhdXRob3JpdGllcyI6W119.sfOYUV6zLpMxgQh6N__qyaN5zVOJjYxwczXJPO0s_lwQNLdSjTjA2_K7bgyz_ZG_8oee-OwOZQftBadEiNOpHg";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

        }
        //GET:Bills

        public ActionResult Index()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<command>>().Result;
                return View(dm);


            }
            else

            {
                Console.WriteLine("Internal server Error");
                return View(new List<command>());
            }
        }
        // GET: Deliveries/Details/5
        public ActionResult Details(long? reference)
        {
            if (reference == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getCommandByReference?reference=" + reference).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<command>().Result;
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
            ViewBag.delivery_id = new SelectList(db.delivery, "id");
            ViewBag.client_id = new SelectList(db.user, "id");
            ViewBag.donation_id = new SelectList(db.donation, "id");



            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reference,total_price,payment_type,order_date,delivery_id,donation_id,client_id")] command command, long? delivery_id, long? donation_id, long? client_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<command>(baseAddress + "addCommand?reference=" + delivery_id + donation_id + client_id, command);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new command());
        }

        public ActionResult Edit(long reference)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllCommandes/" + reference).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var command = tokenResponse.Content.ReadAsAsync<command>().Result;
                return View(command);
            }
            else
            {
                return View(new command());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(command command)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<command>(baseAddress + "updatecommande/", command).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(long reference)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByReference/" + reference).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new command());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(long reference, command command)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByReference/" + reference).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }




        /// /////////////////////////////////////////////////////////////////////////BACK////////////////////////////////////////////////////////////

        /*  public ActionResult stats()
          {
              httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
              httpClient.DefaultRequestHeaders.Accept.Clear();
              httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              //GET Method  
              var response = httpClient.GetAsync(baseAddress + "retrieve-all-usersAnne").Result;
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
                  return View(new List<command>());
              }

          }*/

        //GET:Bills

        public ActionResult IndexB()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<command>>().Result;
                return View(dm);


            }
            else

            {
                Console.WriteLine("Internal server Error");
                return View(new List<command>());
            }
        }
        // GET: Deliveries/Details/5
        public ActionResult DetailsB(long? reference)
        {
            if (reference == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getCommandByReference?reference=" + reference).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<command>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // GET: Deliveries/Create
        public ActionResult CreateB()
        {
            ViewBag.delivery_id = new SelectList(db.delivery, "id");
            ViewBag.client_id = new SelectList(db.user, "id");
            ViewBag.donation_id = new SelectList(db.donation, "id");



            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateB([Bind(Include = "reference,total_price,payment_type,order_date,delivery_id,donation_id,client_id")] command command, long? delivery_id, long? donation_id, long? client_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<command>(baseAddress + "addCommand?reference=" + delivery_id + donation_id + client_id, command);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new command());
        }

        public ActionResult EditB(long reference)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllCommandes/" + reference).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var command = tokenResponse.Content.ReadAsAsync<command>().Result;
                return View(command);
            }
            else
            {
                return View(new command());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditB(command command)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<command>(baseAddress + "updatecommande/", command).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult DeleteB(long reference)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByReference/" + reference).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new command());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult DeleteB(long reference, command command)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByReference/" + reference).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
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

