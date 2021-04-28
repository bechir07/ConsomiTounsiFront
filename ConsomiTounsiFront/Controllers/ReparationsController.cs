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
    public class ReparationsController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress; User u = null;


        public ReparationsController()
        {
            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            u = TokenFixed.GetUser();
        }
        // GET: Reparations
        public ActionResult Index()
        {  //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Reparation/reparations").Result;
            if (response.IsSuccessStatusCode)
            {
                var reparations = response.Content.ReadAsAsync<IEnumerable<reparation>>().Result;
                return View(reparations);
            }
            else
            {

                return HttpNotFound();
            }
        }

        // GET: Reparations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Reparation/reparation?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<reparation>().Result;
                if (r == null)
                {
                    return HttpNotFound();
                }
                return View(r);
            }

            return HttpNotFound();
        }
        
        
        // GET: Reparations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Reparation/reparation?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<reparation>().Result;
                if (r == null)
                {
                    return HttpNotFound();
                }
                
                return View(r);
            }

            return HttpNotFound();
        }

        // POST: Reparations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "id,dateReparation,prixReparation,typePanne,state,idProduct")] reparation reparation,long? idProduct)
        {
            if (ModelState.IsValid)
            {
                httpClient.BaseAddress = new Uri("http://localhost:8082/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //user id get it from session
                var postTask = httpClient.PutAsJsonAsync<reparation>("ConsomiTounsi/Reparation/updateReparation/" + reparation.idProduct, reparation);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(reparation);
        }
    

        // GET: Reparations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Reparation/reparation?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<reparation>().Result;
                if (r == null)
                {
                    return HttpNotFound();
                }
                return View(r);
            }

            return HttpNotFound();
        }

        // POST: Reparations/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
             var postTask = httpClient.DeleteAsync(baseAddress + "ConsomiTounsi/Reparation/deleteReparation?id=" + id);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       
    }
}
