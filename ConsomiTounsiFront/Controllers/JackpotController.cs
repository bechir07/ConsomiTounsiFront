using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsomiTounsiFront.Controllers
{
    public class JackpotController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        String _AccessToken;

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

        // GET: Jackpot
        public ActionResult Index()
        {
            return View();
        }

        // GET: Jackpot/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jackpot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jackpot/Create
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

        // GET: Jackpot/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jackpot/Edit/5
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

        // GET: Jackpot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jackpot/Delete/5
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

        public ActionResult Donate()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "jackpot/getAllJackpot").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Jackpots = tokenResponse.Content.ReadAsAsync<IEnumerable<Jackpot>>().Result;
                return View(Jackpots);
            }
            else
            {
                return View(new List<Jackpot>());
            }
            //return View();
        }
        public ActionResult GetJackpots()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "jackpot/getAllJackpot").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Jackpots = tokenResponse.Content.ReadAsAsync<IEnumerable<Jackpot>>().Result;
                return View(Jackpots);
            }
            else
            {
                return View(new List<Jackpot>());
            }

            //return View();
        }

        public ActionResult GetJackpotStats(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "jackpot/getMaxDonationForJackpot/" + id.ToString()).Result;
            var ApiResponse = httpClient.GetAsync(baseAddress + "jackpot/getSumDonationForJackpot/" + id.ToString()).Result;
            var Api = httpClient.GetAsync(baseAddress + "jackpot/getAvgDonationForJackpot/" + id.ToString()).Result;
            //var ApiResponse = httpClient.GetAsync(baseAddress + "event/getTauxParticipation/" + id.ToString()).Result;
            if (tokenResponse.IsSuccessStatusCode & ApiResponse.IsSuccessStatusCode)
            {
                var max = tokenResponse.Content.ReadAsAsync<double>().Result;
                var sum = ApiResponse.Content.ReadAsAsync<double>().Result;
                var avg = Api.Content.ReadAsAsync<double>().Result;
                var stats = new Dictionary<string, double>();
                stats.Add("Max Donation", max);
                stats.Add("Sum Donation", sum);
                stats.Add("Avg", avg);


                ViewBag.msg = stats;
                return View();
            }
            else
            {
                return RedirectToAction("GetJackpots", "Jackpot");
            }

            //return View();
        }

        public ActionResult GetJackpotSortedBySumDonation()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "jackpot/getJackpotSortedBySumDonation").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Jackpots = tokenResponse.Content.ReadAsAsync<Dictionary<string, double>>().Result;
                ViewBag.MyDictionary = Jackpots;
                return View();
            }
            else
            {
                return RedirectToAction("GetJackpots", "Jackpot");
            }

            //return View();
        }


    }
}
