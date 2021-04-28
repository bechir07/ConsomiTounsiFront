using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using ConsomiTounsi.Models;
using ConsomiTounsiFront.Models;

namespace ConsomiTounsi.Controllers
{
    public class ReclamationsController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress; User u;


        public ReclamationsController()
        {

            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            u = TokenFixed.GetUser();
        }

        // GET: reclamations
        public ActionResult Index()
        {

              //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Reclamation/index").Result;
            if (response.IsSuccessStatusCode)
            {
                 var reclamations = response.Content.ReadAsAsync< IEnumerable<reclamation>>().Result;
                return View(reclamations);
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<reclamation>());
            }


        }

        // GET: reclamations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8082/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync("ConsomiTounsi/Reclamation/reclam?id="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                var reclamations = response.Content.ReadAsAsync<reclamation>().Result;
                if (reclamations == null)
                {
                    return HttpNotFound();
                }
                return View(reclamations);
            }

            return HttpNotFound();
        }

        // GET: reclamations/Create
        public ActionResult Create()
        {
           // ViewBag.users_id = new SelectList(db.User, "id", "username");
            return View();
        }

        // POST: reclamations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "id,dateLimit,decision,objet,state,typeReclamation,users_id")] reclamation reclamation)
        {
           
            reclamation.state = true;
            if (ModelState.IsValid)
            {
                httpClient.BaseAddress = new Uri("http://localhost:8082/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = httpClient.PostAsJsonAsync<reclamation>("ConsomiTounsi/Reclamation/newReclamation?id=" + 2, reclamation);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(new reclamation());
        }

        // GET: reclamations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8082/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync("ConsomiTounsi/Reclamation/reclam?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var reclamations = response.Content.ReadAsAsync<reclamation>().Result;
                if (reclamations == null)
                {
                    return HttpNotFound();
                }
                return View(reclamations);
            }

            return HttpNotFound();

        }

        // POST: reclamations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "id,decision,objet,state,typeReclamation,users_id")] reclamation reclamation)
        {
            reclamation.state = true;
            if (ModelState.IsValid)
            {
                httpClient.BaseAddress = new Uri("http://localhost:8082/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = httpClient.PutAsJsonAsync<reclamation>("ConsomiTounsi/Reclamation/updateReclamation?id=" + 2, reclamation);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
             }
            return View(reclamation);
        }

        // GET: reclamations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8082/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync("ConsomiTounsi/Reclamation/reclam?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var reclamations = response.Content.ReadAsAsync<reclamation>().Result;
                if (reclamations == null)
                {
                    return HttpNotFound();
                }
                return View(reclamations);
            }

            return HttpNotFound();

        }

        // Delete: reclamations/Delete/5
        [HttpPost]
           [ ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8082/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.DeleteAsync("ConsomiTounsi/reclamations/" + id);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public ActionResult Decision(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8082/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync("ConsomiTounsi/Reclamation/reclam?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var reclamations = response.Content.ReadAsAsync<reclamation>().Result;
                if (reclamations == null)
                {
                    return HttpNotFound();
                }
                return View(reclamations);
            }

            return HttpNotFound();

        }

        // POST: reclamations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Decision([Bind(Include = "id,dateLimit,decision,objet,state,typeReclamation,users_id")] reclamation reclamation, float? couponValue, String typePanne, float? prixReparation, long? idProduct)
        {
            reclamation.state = true;
            if (ModelState.IsValid)
            {
                httpClient.BaseAddress = new Uri("http://localhost:8082/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = httpClient.PutAsJsonAsync<reclamation>("ConsomiTounsi/Reclamation/decision?typePanne="+ typePanne+"&prixReparation="+ prixReparation + "&idProduct="+ idProduct + "&idClient="+2+"&couponValue="+ couponValue, reclamation);
                postTask.Wait();
                if (reclamation.decision.Equals("Remboursement"))
                {
                    return RedirectToAction("Create", "Remboursements");
                }

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(reclamation);
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
