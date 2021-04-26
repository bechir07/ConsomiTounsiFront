using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConsomiTounsiFront.Controllers
{
    public class DonationController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        String _AccessToken;
        /*public DonationController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

        }*/
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);

            _AccessToken = ctx.HttpContext.Session["AccessToken"].ToString();
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format(_AccessToken));
        }
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Donation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Donation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Donation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/GetUserDonation
        public ActionResult GetUserDonation()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "GetDonationOfUser").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Donations = tokenResponse.Content.ReadAsAsync<IEnumerable<Donation>>().Result;
                return View(Donations);
            }
            else
            {
                return View(new List<Donation>());
            }
            //return View();
        }
        // GET: Donation/AjoutDonation
        public ActionResult AjoutDonation(int id)
        {
            
            return View();
        }

        // POST: Donation/AjoutDonation
        [HttpPost]
        public ActionResult AjoutDonation(Donation donation,int id)
        {

            
                var APIResponse = httpClient.PostAsJsonAsync<Donation>(baseAddress + "pay/"+id.ToString(),
                donation).Result;
            if (APIResponse.IsSuccessStatusCode)
            {


                var lien = APIResponse.Content.ReadAsStringAsync().Result;
                ViewBag.lien = lien;
                return Redirect(lien);
                //return RedirectToAction("AddDonation");
                //return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddDonation()
        {

            //ViewBag.jname = name;
            //ViewBag.id = id;
            return View();
            
        }

        [HttpPost]
        public ActionResult AddDonation(Donation donation)
        {
            //int id;
            //id = ViewBag.id;
                //donation.jname = ViewBag.jname;
            try
            {
                
                var APIResponse = httpClient.PostAsJsonAsync<Donation>(baseAddress + "pay",
                donation).Result;//.ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                var lien = APIResponse.Content.ReadAsStringAsync().Result;
                ViewBag.lien = lien;
                //return Redirect(lien);
                //return RedirectToAction("AddDonation");
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
