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
    public class UserFormController : Controller
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

        // GET: UserForm
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserForm/Create
        [HttpPost]
        public ActionResult Create(UserForm userform)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<UserForm>("http://localhost:8081/ConsomiTounsi/login",
                userform).Result;//.ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                var token = APIResponse.Headers.GetValues("Authorization").FirstOrDefault();
                Session["AccessToken"] = token;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserForm/Edit/5
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

        // GET: UserForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserForm/Delete/5
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

        // POST: Product/Create
        
        public ActionResult AddAdmin()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult AddAdmin(UserForm userform)
        {
            userform.role = "ADMIN";

            var APIResponse = httpClient.PostAsJsonAsync<UserForm>(baseAddress + "register", userform).Result;

            if (APIResponse.IsSuccessStatusCode)
            {


                var msg = APIResponse.Content.ReadAsStringAsync().Result;
                //ViewBag.lien = lien;
                return RedirectToAction("GetUsers","User");
                //return RedirectToAction("AddDonation");
                //return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult AddUser(UserForm userform)
        {
            userform.role = "USER";

            var APIResponse = httpClient.PostAsJsonAsync<UserForm>(baseAddress + "register", userform).Result;

            if (APIResponse.IsSuccessStatusCode)
            {


                var msg = APIResponse.Content.ReadAsStringAsync().Result;
                //ViewBag.lien = lien;
                return RedirectToAction("Create", "UserLogin");
                //return RedirectToAction("AddDonation");
                //return View();
            }
            else
            {
                return View();
            }
        }

    }
}
