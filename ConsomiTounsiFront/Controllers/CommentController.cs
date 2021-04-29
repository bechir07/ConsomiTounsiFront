using ConsomiTounsiFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsomiTounsiFront.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        private consomitounsiEntities db = new consomitounsiEntities();

        HttpClient httpClient;
        string baseAddress;

        public CommentController()
        {
            baseAddress = "http://localhost:8081/ConsomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJtb250YSIsImV4cCI6MTYxOTU3MTY2MSwiaWF0IjoxNjE5NTUzNjYxLCJhdXRob3JpdGllcyI6W119.sfOYUV6zLpMxgQh6N__qyaN5zVOJjYxwczXJPO0s_lwQNLdSjTjA2_K7bgyz_ZG_8oee-OwOZQftBadEiNOpHg";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }
        //GET:Bills
        public ActionResult Index()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllComments").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<comment>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<comment>());
            }
        }
        /* public ActionResult DownloadViewPDF()
         {
             return new PdfLibrary.ViewAsPdf("DemoAsPDF");
         }*/
        // GET: Deliveries/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "comments?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<comment>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.subject, "id", "id");
            ViewBag.users_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,content_comment,date_comment,subject_id,users_id")] comment comment, long? subject_id, long? users_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<comment>(baseAddress + "addComment?id=" + subject_id + users_id, comment);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new comment());
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllComments/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var comment = tokenResponse.Content.ReadAsAsync<comment>().Result;
                return View(comment);
            }
            else
            {
                return View(new comment());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(comment comment)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<comment>(baseAddress + "updateComment/", comment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletecommentById/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new comment());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, comment comment)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletecommentById/" + id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////////BACK/////////////////////////////////////////////////////////////////////



        //GET:Bills
        public ActionResult IndexB()
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "getAllComments").Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<IEnumerable<comment>>().Result;
                return View(dm);


            }
            else
            {
                Console.WriteLine("Internal server Error");
                return View(new List<comment>());
            }
        }
        /* public ActionResult DownloadViewPDF()
         {
             return new PdfLibrary.ViewAsPdf("DemoAsPDF");
         }*/
        // GET: Deliveries/Details/5
        public ActionResult DetailsB(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync(baseAddress + "comments?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var dm = response.Content.ReadAsAsync<comment>().Result;
                if (dm == null)
                {
                    return HttpNotFound();
                }
                return View(dm);
            }

            return HttpNotFound();
        }

        // GET: Deliveries/Create
        public ActionResult CreateB()
        {
            ViewBag.subject_id = new SelectList(db.subject, "id", "id");
            ViewBag.users_id = new SelectList(db.user, "id", "email");
            return View();
        }

        // POST: Deliveries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateB([Bind(Include = "id,content_comment,date_comment,subject_id,users_id")] comment comment, long? subject_id, long? users_id)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8081/ConsomiTounsi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = httpClient.PostAsJsonAsync<comment>(baseAddress + "addComment?id=" + subject_id + users_id, comment);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(new comment());
        }

        // GET: Bills/Edit/5
        public ActionResult EditB(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getAllComments/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var comment = tokenResponse.Content.ReadAsAsync<comment>().Result;
                return View(comment);
            }
            else
            {
                return View(new comment());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditB(comment comment)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<comment>(baseAddress + "updateComment/", comment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bills/Delete/5
        public ActionResult DeleteB(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletecommentById/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new comment());
            }
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult DeleteB(long id, comment comment)
        {
            try
            {
                var tokenResponse = httpClient.DeleteAsync(baseAddress + "deletecommentById/" + id).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
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


