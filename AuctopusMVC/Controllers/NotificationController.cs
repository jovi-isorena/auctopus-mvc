using AuctopusMVC.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.Models;
using Newtonsoft.Json;
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
        public JsonResult NotificationCount(string id)
        {
            //string gg = HttpContext.Request.Path;
            //return gg;
            int count = NotificationProcessor.GetUnreadNotificationsCount(Int32.Parse(id));
            var json = JsonConvert.SerializeObject(count);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult NotificationList(string id)
        {
            List<NotificationModel> notifs = NotificationProcessor.GetUnreadNotifications(Int32.Parse(id));
            return PartialView("_NotificationList", notifs);
        }

        public ActionResult RedirectNotification(string id)
        { 
            
            string[] link = NotificationProcessor.GetNotification(Int32.Parse(id)).Link.Split('/');
            NotificationProcessor.ReadNotification(Int32.Parse(id));
            return RedirectToAction(link[2] + "/" + link[3], link[1]);
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
