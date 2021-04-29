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
    public class BillController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress;

        public BillController()
        {


            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJtb250YSIsImV4cCI6MTYxOTU4OTk1MiwiaWF0IjoxNjE5NTcxOTUyLCJhdXRob3JpdGllcyI6W119.B5sIM7WRK-HBKqH9Ct8F5CxTHBiGa--YlAwbgUzpT_0bhL8WSj71OBVSTVgN767PMq31-8x2nDNg5bKm_nEn8A";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

        }
        //GET:Bills
        public ActionResult Index()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GET Method  
            var response = httpClient.GetAsync("getAllBillM").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<bill>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<bill>());
            }
        }

      /*  public ActionResult Pdf()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GET Method  
            //var response = httpClient.GetAsync("pdf").Result;
            /*  var tokenResponse = httpClient.GetAsync(baseAddress + "pdf/" ).Result;


              return View();*/
      /*
            var response = httpClient.GetAsync("pdf").Result;
            if (response.IsSuccessStatusCode)
            {
                return View();


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<bill>());
            }


        }
*/

        /////////////////////////////////////////////////
        public ActionResult pdf()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "pdf").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
               // var products = tokenResponse.Content.ReadAsAsync<>().Result;
                return View();
            }
            else
            {
                return View(new List<bill>());
            }
        }
                ///////////////////////////////////////////
                
                // GET: Deliveries/Details/5
                public ActionResult Details(long? bill_id)
        {
            if (bill_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GET Method  
            var response = httpClient.GetAsync("getAllBillM?bill_id=" + bill_id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<bill>().Result;
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
           // ViewBag.CategoryList = new SelectList(categoryService.GetMany(), "CategoryId", "Name");

            ViewBag.command_reference = new SelectList(db.command, "reference","reference");
            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bill_id,total_price,state,payment_type,date_of_bill,command_reference")] bill bill, long? command_reference)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var postTask = httpClient.PostAsJsonAsync<bill>("addBill/" + command_reference, bill);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new bill());
        }

        // GET: Bills/Edit/5
        /*  public ActionResult Edit(long? bill_id)
          {
              if (bill_id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
              httpClient.DefaultRequestHeaders.Accept.Clear();
              httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

              //GET Method  
              var response = httpClient.GetAsync("updateBill/" + bill_id).Result;
              if (response.IsSuccessStatusCode)
              {
                  var dm = response.Content.ReadAsAsync<bill>().Result;
                  if (dm == null)
                  {
                      return HttpNotFound();
                  }
                  ViewBag.command_reference = new SelectList(db.command, "reference");

                  return View(dm);
              }

              return HttpNotFound();
          }
          */
        /*
                public ActionResult Edit(long? bill_id)
                {
                    if (bill_id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    var response = httpClient.GetAsync("updateBill/?id=" + bill_id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var bills = response.Content.ReadAsAsync<bill>().Result;
                        if (bills == null)
                        {
                            return HttpNotFound();
                        }
                        return View(bills);
                    }

                    return HttpNotFound();

                }*/
        // POST: Deliveries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "bill_id,total_price,state,payment_type,date_of_bill,command_reference")] bill bill, long? command_reference)
         {
             if (ModelState.IsValid)
             {
                 httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
                 httpClient.DefaultRequestHeaders.Accept.Clear();
                 httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                 var postTask = httpClient.PutAsJsonAsync<bill>( "updateBill/", bill);
                 postTask.Wait();

                 var result = postTask.Result;
                 if (result.IsSuccessStatusCode)
                 {
                     return RedirectToAction("Index");
                 }
             }
             return View(bill);
         }
         */

        //

 







        public ActionResult Edit(long bill_id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllBillM/" + bill_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var bill = tokenResponse.Content.ReadAsAsync<bill>().Result;
                return View(bill);
            }
            else
            {
                return View(new bill());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(bill bill)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<bill>(baseAddress + "updateBill/", bill).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }










        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit([Bind(Include = "bill_id,total_price,state,payment_type,date_of_bill,command_reference")] bill bill)
                {
                    //bill.state = true;
                    if (ModelState.IsValid)
                    {
                        httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var postTask = httpClient.PutAsJsonAsync<bill>("updateBill?id=" + 1 , bill);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    return View(bill);
                }
                */


        // GET: Bills/Delete/5
        public ActionResult Delete(long bill_id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletebillById/" + bill_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new bill());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(long bill_id, bill bill)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletebillById/" + bill_id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        /////////////////////////////////////////////////////back/////////////////////////////////////////////////////////


        //GET:Bills
        public ActionResult IndexB()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GET Method  
            var response = httpClient.GetAsync("getAllBillM").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<bill>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<bill>());
            }
        }
        // GET: Deliveries/Details/5
        public ActionResult DetailsB(long? bill_id)
        {
            if (bill_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GET Method  
            var response = httpClient.GetAsync("Bills?bill_id=" + bill_id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<bill>().Result;
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
            ViewBag.command_reference = new SelectList(db.command, "reference");
            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateB([Bind(Include = "bill_id,total_price,state,payment_type,date_of_bill,command_reference")] bill bill, long? command_reference)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var postTask = httpClient.PostAsJsonAsync<bill>("addBill/" + command_reference, bill);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new bill());
        }

       
        public ActionResult EditB(long bill_id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllBillM/" + bill_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var bill = tokenResponse.Content.ReadAsAsync<bill>().Result;
                return View(bill);
            }
            else
            {
                return View(new bill());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditB(bill bill)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<bill>(baseAddress + "updateBill/", bill).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }











        // GET: Bills/Delete/5
        public ActionResult DeleteB(long bill_id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletebillById/" + bill_id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new bill());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult DeleteB(long bill_id, bill bill)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletebillById/" + bill_id).Result;
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

