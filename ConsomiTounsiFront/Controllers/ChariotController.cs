using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsomiTounsiFront.Controllers
{
    public class ChariotController : Controller
    {
        // GET: Chariot
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chariot/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chariot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chariot/Create
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

        // GET: Chariot/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chariot/Edit/5
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

        // GET: Chariot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chariot/Delete/5
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
