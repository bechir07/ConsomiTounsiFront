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
    public class UserController : Controller
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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        public ActionResult GetUsers()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAdmins").Result;
            var ApiResponse = httpClient.GetAsync(baseAddress + "getUsers").Result;
            //var ApiResponse = httpClient.GetAsync(baseAddress + "event/getTauxParticipation/" + id.ToString()).Result;
            if (tokenResponse.IsSuccessStatusCode & ApiResponse.IsSuccessStatusCode)
            {

                var Users = ApiResponse.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                var Admins = tokenResponse.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                ViewBag.Admins = Admins;
                ViewBag.Users = Users;
                return View();

                
                
            }
            else
            {
                return RedirectToAction("GetEvents", "Event");
            }

            //return View();
        }


    }
}
