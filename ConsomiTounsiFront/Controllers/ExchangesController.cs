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
    public class ExchangesController : Controller
    {
        private consomitounsiEntities db = new consomitounsiEntities();
        System.Net.Http.HttpClient httpClient;
        string baseAddress;  User u = null;


        public ExchangesController()
        {
            baseAddress = "http://localhost:8082/";
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TokenFixed.token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            u = TokenFixed.GetUser();
        }

        // GET: Exchanges
        public ActionResult Index()
        { var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Exchange/exchanges").Result;
            if (response.IsSuccessStatusCode)
            {
                var echanges = response.Content.ReadAsAsync<IEnumerable<exchange>>().Result;
                return View(echanges);
            }
            else
            {

                return HttpNotFound();
            }
        }

        public ActionResult ExchangeByUser()
        {
           //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Exchange/exchangesByUsers/" +u.id).Result;
            if (response.IsSuccessStatusCode)
            {
                var echanges = response.Content.ReadAsAsync<IEnumerable<exchange>>().Result;
                return View(echanges);
            }
            else
            {

                return HttpNotFound();
            }
        }

        // GET: Exchanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Exchange/exchangesById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var exchange = response.Content.ReadAsAsync<exchange>().Result;
                if (exchange == null)
                {
                    return HttpNotFound();
                }
                return View(exchange);
            }

            return HttpNotFound();
        }

        
        // GET: Exchanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Exchange/exchangesById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var exchange = response.Content.ReadAsAsync<exchange>().Result;
                if (exchange == null)
                {
                    return HttpNotFound();
                }
                return View(exchange);
            }

            return HttpNotFound();
        }

        // POST: Exchanges/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Edit([Bind(Include = "numCoupon,couponValue,dateLimite,users_id,state")] exchange exchange)
        {
            //user id get it from session
            var postTask = httpClient.PutAsJsonAsync<exchange>(baseAddress + "ConsomiTounsi/Exchange/updateExchange/" + u.id, exchange);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        
            return View(exchange);
        }

        // GET: Exchanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "ConsomiTounsi/Exchange/exchangesById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var exchange = response.Content.ReadAsAsync<exchange>().Result;
                if (exchange == null)
                {
                    return HttpNotFound();
                }
                return View(exchange);
            }

            return HttpNotFound();
        }

        // POST: Exchanges/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            
            var postTask = httpClient.DeleteAsync(baseAddress + "ConsomiTounsi/Exchange/deleteExchange?id=" + id);
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
