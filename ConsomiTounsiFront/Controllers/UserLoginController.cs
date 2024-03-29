﻿using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsomiTounsiFront.Controllers
{
    public class UserLoginController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public UserLoginController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = "eyJhbGciOiJ9.eyJzdWIiOiJiYWNoIiwiZXhwIjoxNjE3MTcwMDY3LCJpYXQiOjE2MTcxNTIwNjcsImF1dGhvcml0aWVzIjpbXX0.wSE6ZXmIP - pLx4xOgtT7gEcKxVav71tYgL5ACp6BgK_F2u90n2LnMVkul9Bvmiou9wfrzgka4CWXSF2d1NmXxA";
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

        }
        // GET: UserLogin
        public ActionResult Index()
        {
            //ViewBag.Token = Session["AccessToken"];
            return View();
        }

        // GET: UserLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
        [HttpPost]
        public ActionResult Create(UserLogin userlogin)
        {
            
                var APIResponse = httpClient.PostAsJsonAsync<UserLogin>("http://localhost:8081/ConsomiTounsi/login",
                userlogin).Result;//.ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            
                var token = APIResponse.Headers.GetValues("Authorization").FirstOrDefault().ToString();
                var us = APIResponse.Content.ReadAsAsync<User>().Result;
                Session["AccessToken"] = token;
                ViewBag.Token = token;
                string role;
                role = "USER";
                bool s;
                s = false;
                foreach (var item in us.roles)
                {
                    if (role.Equals(item.roleName))
                    {
                        //return RedirectToAction("ListEvent", "Event");
                        s = true;
                    }
                    
                }

            if (s == true) { return RedirectToAction("ListEvent", "Event"); }

            else { return RedirectToAction("GetEvents", "Event"); }
                //return View();
            
                
            
        }

        // GET: UserLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserLogin/Edit/5
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

        // GET: UserLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserLogin/Delete/5
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
