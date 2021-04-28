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
    public class Command_lineController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();

        HttpClient httpClient;
        string baseAddress;

        public Command_lineController()
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
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes_line").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<command_line>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<command_line>());
            }
        }


        // GET: Deliveries/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes_line?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<command_line>().Result;
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
            ViewBag.command_reference = new SelectList(db.command, "reference", "id");
            ViewBag.product_id = new SelectList(db.product, "id", "id");

            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,amount,total_product_price,command_reference,product_id")] command_line command_line, long? command_reference, long? product_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();


            var postTask = httpClient.PostAsJsonAsync<command_line>(baseAddress + "addCommand_line?id=" + command_line.command_reference + "&id=" + command_line.product_id, command_line);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new command_line());
        }

        public ActionResult Edit(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllCommandes_line/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var command_line = tokenResponse.Content.ReadAsAsync<command_line>().Result;
                return View(command_line);
            }
            else
            {
                return View(new command_line());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(command_line command_line)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<command_line>(baseAddress + "updatecommande_line/", command_line).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByidc/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new command_line());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, command_line command_line)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByidc/" + id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        ///////////////////////////////////////////////////////////////BACK///////////////////////////////////////////////////////////////////









        //GET:Bills
        public ActionResult IndexB()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes_line").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<command_line>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<command_line>());
            }
        }


        // GET: Deliveries/Details/5
        public ActionResult DetailsB(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllCommandes_line?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<command_line>().Result;
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
            ViewBag.command_reference = new SelectList(db.command, "reference", "id");
            ViewBag.product_id = new SelectList(db.product, "id", "id");

            //ViewBag.deliver_men_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateB([Bind(Include = "id,amount,total_product_price,command_reference,product_id")] command_line command_line, long? command_reference, long? product_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();


            var postTask = httpClient.PostAsJsonAsync<command_line>(baseAddress + "addCommand_line?id=" + command_line.command_reference + "&id=" + command_line.product_id, command_line);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new command_line());
        }

        public ActionResult EditB(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllCommandes_line/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var command_line = tokenResponse.Content.ReadAsAsync<command_line>().Result;
                return View(command_line);
            }
            else
            {
                return View(new command_line());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditB(command_line command_line)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<command_line>(baseAddress + "updatecommande_line/", command_line).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult DeleteB(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByidc/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new command_line());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult DeleteB(long id, command_line command_line)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteByidc/" + id).Result;
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

