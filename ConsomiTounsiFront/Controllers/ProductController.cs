using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJtb250YSIsImV4cCI6MTYxOTU1Mjk5NywiaWF0IjoxNjE5NTM0OTk3LCJhdXRob3JpdGllcyI6W119.2PXSgggyJurlJ7DpJB9RbZolw1hTkgNoM_RZ76D-RfrRSxKcDUQ-yKyCyKKGORFEPDn00YamaQyZ70NkAOwAHA";
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
            var tokenResponse = httpClient.GetAsync(baseAddress + "addProduct"  ).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var product = tokenResponse.Content.ReadAsAsync<Product>().Result;
                return View(product);
            }
            else
            {
                return View(new Product());
            }
        }
        public ViewResult Createt() => View();

        // POST: Product/Create
        [HttpPost]
        
        public ActionResult Create(Product p)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Product>(baseAddress + "addProduct",
                p).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }




        // GET: Product/Edit/5
        public ActionResult Edit(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getProduct/"+id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var product = tokenResponse.Content.ReadAsAsync<Product>().Result;
                return View(product);
            }
            else
            {
                return View(new Product());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Product>(baseAddress + "updateProduct/", product).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteProduct/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new Product());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(long id,Product product)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deleteProduct/" +id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
