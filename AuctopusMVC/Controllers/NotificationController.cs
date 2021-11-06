using AuctopusMVC.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctopusMVC.Controllers
{
    public class NotificationController : Controller
    {
        //
        // GET: /Notification/

        public ActionResult Index()
        {

            List<NotificationModel> notifs = NotificationProcessor.LoadNotifications(Int32.Parse(Session["UserId"].ToString()));

            return View(notifs);
        }


        //
        // GET: /Notification/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Notification/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Notification/Create

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

        //
        // GET: /Notification/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Notification/Edit/5

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

        //
        // GET: /Notification/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Notification/Delete/5

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
