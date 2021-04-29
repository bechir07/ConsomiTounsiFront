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
    public class RemboursementsController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;User u;string baseAddress;

        public RemboursementsController()
        {
            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            u = TokenFixed.GetUser();
        }

        // GET: remboursements
        public ActionResult Index()
        {

            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Remboursement").Result;
            if (response.IsSuccessStatusCode)
            {
                var remboursements = response.Content.ReadAsAsync<IEnumerable<remboursement>>().Result;
                return View(remboursements);
            }
            else
            {

                return HttpNotFound();
            }
        }

       

        // GET: remboursements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: remboursements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,amount,currency,description,receipt_email,stripeToken")] remboursement remboursement)
        {
            remboursement.stripeToken = "tok_1IZBxyFyOQUsjJ1EzcJt6XXU";
            if (ModelState.IsValid)
            {
                var postTask = httpClient.PostAsJsonAsync<remboursement>(baseAddress + "ConsomiTounsi/charge", remboursement);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Reclamations");
                }
            }

            return HttpNotFound();
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
