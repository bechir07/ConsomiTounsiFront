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
    public class EventController : Controller
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
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult EditEvent(int id)
        {
            var ApiResponse = httpClient.GetAsync(baseAddress + "event/getEventById/" + id.ToString()).Result;
            if (ApiResponse.IsSuccessStatusCode)
            {
                var Event = ApiResponse.Content.ReadAsAsync<Event>().Result;
                return View(Event);
            }
            return RedirectToAction("GetEvents","Event");
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult EditEvent(int id, Event eventt, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    eventt.imagename = file.FileName;

                    if (file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                        file.SaveAs(path);
                    }
                }
                var APIResponse = httpClient.PostAsJsonAsync<Event>("http://localhost:8081/ConsomiTounsi/event/addEvent",
                eventt).Result;
                if (APIResponse.IsSuccessStatusCode)
                {


                    var msg = APIResponse.Content.ReadAsStringAsync().Result;
                    //ViewBag.lien = lien;
                    return RedirectToAction("GetEvents", "Event");
                    //return RedirectToAction("AddDonation");
                    //return View();
                }

                else
                    return View();


            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var APIResponse = httpClient.GetAsync(baseAddress + "desaffecterUserAEvent/" + id.ToString()).Result;
            var ms = APIResponse.Content.ReadAsStringAsync().Result;
            ViewBag.msg = APIResponse;
            if (APIResponse.IsSuccessStatusCode)
            {
                   var msg = APIResponse.Content.ReadAsStringAsync().Result;
                
                    return RedirectToAction("GetUserEvent", "Event"); 
            }

            else
            {
                return RedirectToAction("Failed", "Event");
            }
        }
        public ActionResult DeleteEvent(int id)
        {
            var APIResponse = httpClient.DeleteAsync(baseAddress + "event/deleteEvent/" + id.ToString()).Result;
            var ms = APIResponse.Content.ReadAsStringAsync().Result;
            //ViewBag.msg = APIResponse;
            if (APIResponse.IsSuccessStatusCode)
            {
                var msg = APIResponse.Content.ReadAsStringAsync().Result;

                return RedirectToAction("GetEvents", "Event");
            }

            else
            {
                return RedirectToAction("GetEvents", "Event");
            }
        }

        // POST: Event/Delete/5
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
        
        // GET: Event/ListEvent
        public ActionResult ListEvent()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "event/getAllEvent").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Events = tokenResponse.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return View(Events);
            }
            else
            {
                return View(new List<Event>());
            }
            
            //return View();
        }
        // POST: Event/ListEvent/5
        
        public ActionResult Participate(int id)
        {
            
            var APIResponse = httpClient.GetAsync(baseAddress + "affecterUserAEvent/"+ id.ToString()).Result;
            var ms = APIResponse.Content.ReadAsStringAsync().Result;
            ViewBag.msg = APIResponse;
            if (APIResponse.IsSuccessStatusCode)
            {


                var msg = APIResponse.Content.ReadAsStringAsync().Result;
                if (msg == "success") 
                {
                    return RedirectToAction("GetUserEvent", "Event"); 
                }
                else
                {
                    return RedirectToAction("Failed", "Event");
                }
                
            }
            else
            {
                return View();
            }
        }
        public ActionResult GetUserEvent()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "GetEventOfUser").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Events = tokenResponse.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return View(Events);
            }
            else
            {
                return View(new List<Event>());
            }
            //return View();
        }
        public ActionResult Failed()
        {
            
            return View();
        }
        
        // GET: Event/GetEvents
        public ActionResult GetEvents()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "event/getAllEvent").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Events = tokenResponse.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return View(Events);
            }
            else
            {
                return View(new List<Event>());
            }

            //return View();
        }

        // GET: Event/GetEvents
        public ActionResult GetEventSortedByParticipation()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "event/getEventSortedByParticipation").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var Events = tokenResponse.Content.ReadAsAsync<Dictionary<string,int>>().Result;
                ViewBag.MyDictionary = Events;
                return View();
            }
            else
            {
                return RedirectToAction("GetEvents","Event");
            }

            //return View();
        }

        // GET: Product/Create
        public ActionResult AjoutEvent()
        {
            
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult AjoutEvent(Event eventt, HttpPostedFileBase file)
        {
            eventt.imagename = file.FileName;

            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }

            var APIResponse = httpClient.PostAsJsonAsync<Event>("http://localhost:8081/ConsomiTounsi/event/addEvent",
                eventt).Result;
            if (APIResponse.IsSuccessStatusCode)
            {


                var msg = APIResponse.Content.ReadAsStringAsync().Result;
                //ViewBag.lien = lien;
                return RedirectToAction("GetEvents", "Event");
                //return RedirectToAction("AddDonation");
                //return View();
            }
            else
            {
                return View();
            }
        }


        public ActionResult GetNbreParticipation(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "event/getNbreParticipantsByEvent/"+id.ToString()).Result;
            var ApiResponse = httpClient.GetAsync(baseAddress + "event/getTauxParticpationPourEvent/" + id.ToString()).Result;
            //var ApiResponse = httpClient.GetAsync(baseAddress + "event/getTauxParticipation/" + id.ToString()).Result;
            if (tokenResponse.IsSuccessStatusCode & ApiResponse.IsSuccessStatusCode)
            {
                var nbre = tokenResponse.Content.ReadAsAsync<int>().Result;
                var taux = ApiResponse.Content.ReadAsAsync<int>().Result;
                var stats = new Dictionary<string, int>();
                stats.Add("Nbre", nbre);
                stats.Add("Taux %", taux);
                stats.Add("Diposnibility", 50 - nbre);


                ViewBag.msg = stats;
                return View();
            }
            else
            {
                return RedirectToAction("GetEvents", "Event");
            }

            //return View();
        }

        public ActionResult GetMaxParticipationForEvent()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "event/getMaxParticipationForEvent").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var max = tokenResponse.Content.ReadAsAsync<Dictionary<string, int>>().Result;
                ViewBag.Max = max;
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
