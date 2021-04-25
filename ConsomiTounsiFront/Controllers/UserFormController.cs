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
        public UserFormController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = "eyJhbGciOiJ9.eyJzdWIiOiJiYWNoIiwiZXhwIjoxNjE3MTcwMDY3LCJpYXQiOjE2MTcxNTIwNjcsImF1dGhvcml0aWVzIjpbXX0.wSE6ZXmIP - pLx4xOgtT7gEcKxVav71tYgL5ACp6BgK_F2u90n2LnMVkul9Bvmiou9wfrzgka4CWXSF2d1NmXxA";
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

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
    }
}
