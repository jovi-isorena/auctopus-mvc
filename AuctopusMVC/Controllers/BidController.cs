using AuctopusMVC.Models;
using DataLibrary.BusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctopusMVC.Controllers
{
    public class BidController : Controller
    {
        //
        // GET: /Bid/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Bid/HighestBid/5
        
        public JsonResult HighestBid(string id)
        {
            //string gg = HttpContext.Request.Path;
            //return gg;
            Bid bid = new Bid(BidProcessor.GetHighestBid(Int32.Parse(id)));
            var json = JsonConvert.SerializeObject(bid);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult HighestB(string id)
        {
            //string gg = HttpContext.Request.Path;
            //return gg;
            Bid bid = new Bid(BidProcessor.GetHighestBid(Int32.Parse(id)));
            //var json = JsonConvert.SerializeObject(bid);
            return PartialView("_HighestBid", bid);
        }
    }
}
