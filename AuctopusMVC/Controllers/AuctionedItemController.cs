using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.BusinessLogic;
using AuctopusMVC.Models;
using DataLibrary.Models;

namespace AuctopusMVC.Controllers
{
    public class AuctionedItemController : Controller
    {
        //
        // GET: /AuctionedItem/

        public ActionResult Index()
        {
            List<AuctionedItemModel> dbList = AuctionedItemProcessor.LoadAuctionedItems();
            List<AuctionedItem> items = new List<AuctionedItem>();
            foreach (AuctionedItemModel item in dbList) {
                //items.Add(new AuctionedItem { 
                //    AuctionedItemId = item.AuctionedItemId,
                //    Name = item.Name,
                //    Description = item.Description,
                //    ImageURL = item.ImageURL,
                //    BidMethod = item.BidMethod,
                //    AuctionStartDate = item.AuctionStartDateTime.Date,
                //    AuctionStartTime = item.AuctionStartDateTime,
                //    AuctionEndDate = item.AuctionEndDateTime.Date,
                //    AuctionEndTime = item.AuctionEndDateTime,
                //    InitialBid = item.InitialBid,
                //    Status = item.Status
                //});
                items.Add(new AuctionedItem(item));
            }

            return View(items);
        }

        //
        // GET: /AuctionedItem/Details/5

        public ActionResult Details(int id)
        {
            AuctionedItem item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(id));
            return View(item);
        }

        //
        // GET: /AuctionedItem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AuctionedItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionedItem a)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                DateTime start = a.AuctionStartDate.Date + a.AuctionStartTime.TimeOfDay;
                DateTime end = a.AuctionEndDate.Date + a.AuctionEndTime.TimeOfDay;
                a.ImageURL = ".\\Images\\" + a.ImageURL;
                int recordCreated = AuctionedItemProcessor.Create(a.Name, a.Description, a.ImageURL,a.Category, a.BidMethod, start, end, a.InitialBid);
                return RedirectToAction("Index");
            }
            
            return View();
            
        }
        
        //
        // GET: /AuctionedItem/Edit/5

        public ActionResult Edit(int id)
        {
            AuctionedItem item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(id));
            return View(item);
        }

        //
        // POST: /AuctionedItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuctionedItem item)
        {

            if (ModelState.IsValid) 
            {
                // TODO: Add update logic here
                DateTime start = item.AuctionStartDate.Date + item.AuctionStartTime.TimeOfDay;
                DateTime end = item.AuctionEndDate.Date + item.AuctionEndTime.TimeOfDay;
                int recordUpdated = AuctionedItemProcessor.Edit(id, item.Name, item.Description, item.ImageURL, item.Category, item.BidMethod, start, end, item.InitialBid, item.Status);
                return RedirectToAction("Index");
            }
                
            return View();
            
        }

        //
        // GET: /AuctionedItem/Delete/5

        public ActionResult Archive(int id)
        {
            AuctionedItem item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(id));
            return View(item);
        }

        //
        // POST: /AuctionedItem/Delete/5

        [HttpPost]
        public ActionResult Archive(int id, AuctionedItem item)
        {
            try
            {
                // TODO: Add delete logic here
               int record = AuctionedItemProcessor.Archive(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
