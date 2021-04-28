using ConsomiTounsiFront.Models;
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
    public class PaymentController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();

        HttpClient httpClient;
        string baseAddress;

        public PaymentController()
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
            var response = httpClient.GetAsync(baseAddress + "getAllPayment").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<payment>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<payment>());
            }
        }
        // GET: Deliveries/Details/5
        public ActionResult Details(long? payment_id)
        {
            if (payment_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "payments?payment_id=" + payment_id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<payment>().Result;
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
            ViewBag.payment_id = new SelectList(db.payment, "payment_id", "payment_id");
            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "payment_id,payment_date,payment_type,total_price,bill_bill_id")] payment payment, long? bill_bill_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<payment>(baseAddress + "addPayment?payment_id=" + payment.bill_bill_id, payment);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new payment());
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(long payment_id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllPayment/" + payment_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var payment = tokenResponse.Content.ReadAsAsync<payment>().Result;
                return View(payment);
            }
            else
            {
                return View(new payment());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(payment payment)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<payment>(baseAddress + "updatepayment/", payment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(long payment_id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteById/" + payment_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new payment());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(long payment_id, payment payment)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteById/" + payment_id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        //////////////////////////////////////////////////////////////////////////////////BACK////////////////////////////////////////////////////////////////





        //GET:Bills
        public ActionResult IndexB()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllPayment").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<payment>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<payment>());
            }
        }
        // GET: Deliveries/Details/5
        public ActionResult DetailsB(long? payment_id)
        {
            if (payment_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "payments?payment_id=" + payment_id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<payment>().Result;
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
            ViewBag.payment_id = new SelectList(db.payment, "payment_id", "payment_id");
            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateB([Bind(Include = "payment_id,payment_date,payment_type,total_price,bill_bill_id")] payment payment, long? bill_bill_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<payment>(baseAddress + "addPayment?payment_id=" + payment.bill_bill_id, payment);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new payment());
        }

        // GET: Bills/Edit/5
        public ActionResult EditB(long payment_id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllPayment/" + payment_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var payment = tokenResponse.Content.ReadAsAsync<payment>().Result;
                return View(payment);
            }
            else
            {
                return View(new payment());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditB(payment payment)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<payment>(baseAddress + "updatepayment/", payment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult DeleteB(long payment_id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteById/" + payment_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new payment());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult DeleteB(long payment_id, payment payment)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteById/" + payment_id).Result;
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

