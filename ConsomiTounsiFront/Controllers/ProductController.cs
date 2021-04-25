using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsomiTounsiFront.Controllers
{
    public class ProductController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public ProductController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJoYWplciIsImV4cCI6MTYxOTM2NjM2MiwiaWF0IjoxNjE5MzQ4MzYyLCJhdXRob3JpdGllcyI6W119.Rr7ynjqbGjihRQo3IWnWPh0Gr0uQeUzjSdsdPFwKq5wNhfWkSVtUcOMDSe3AHePzLFwuiZFXrmIMCX7liTQrhw";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }
        // GET: Product
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "retrieve-all-products").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var products = tokenResponse.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return View(products);
            }
            else
            {
                return View(new List<Product>());
            }
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFile file)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Product>(baseAddress + "addProductFront"+file,p).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                //var path = Path.Combine(Server.MapPath("C:\\Users\\ell\\Desktop\\consomitounsi\\product"),file.FileName);

                //file.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
