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
    public class AuctionController : Controller
    {
        //
        // GET: /Auction/

        public ActionResult Index(string category, string query)
        {

            List<AuctionModel> dbList = AuctionProcessor.LoadAuctions(category, query);
            List<Auction> auctions = new List<Auction>();
            foreach (AuctionModel item in dbList)
            {
                auctions.Add(new Auction(item));
            }
            return View(auctions);
        }

        
        //
        // GET: /bid/Details/5

        
        //
        // GET: /Auction/Room/1

        public ActionResult Room(int id)
        {
            Auction auc = new Auction();
            auc.Item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(id));
            var highest = BidProcessor.GetHighestBid(id);
            if (highest != null)
                auc.HighestBid = new Bid(highest);
            else
                auc.HighestBid = new Bid();
            auc.NewBid = new Bid { 
                ItemId = id,
                UserId = Convert.ToInt32(Session["UserId"])
            };
            return View(auc);
        }

        //
        // POST: /Auction/Room/1

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Room(int id, FormCollection form)
        {
            var highest = BidProcessor.GetHighestBid(id);
            var newbid = Convert.ToDouble(form["NewBid.Amount"]);
            var userid = Convert.ToInt32(Session["UserId"]);
            if (form["NewBid.Amount"] != null)
            {
                // TODO: Add insert logic here
                try
                {
                    if (newbid > highest.Amount && userid != highest.UserId)
                    {
                        int record = BidProcessor.Create(Convert.ToInt32(form["Item.AuctionedItemId"]), userid, newbid);
                        NotificationProcessor.Create(NotificationType.OutBid, highest.UserId, highest.ItemId);
                    }
                    else
                    {
                        //error message here, new bid is lower
                    }
                }
                catch (NullReferenceException) 
                {
                    int record = BidProcessor.Create(Convert.ToInt32(form["Item.AuctionedItemId"]), userid, newbid);
                }
                
                

            }
            else 
            { 
            
            }
            //get updated auction information
            Auction auc = new Auction();
            auc.Item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(id));
            highest = BidProcessor.GetHighestBid(id);
            if (highest != null)
                auc.HighestBid = new Bid(highest);
            
            auc.NewBid = new Bid
            {
                ItemId = id,
                UserId = Convert.ToInt32(Session["UserId"])
            };
            return View(auc);
           
        }

        public JsonResult HighestBid(int itemId)
        {
            Bid bid = new Bid(BidProcessor.GetHighestBid(itemId));
            var json = JsonConvert.SerializeObject(bid);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AwardItems()
        {
            List<AuctionModel> dbList = AuctionProcessor.LoadEndedAuctions();
            List<Auction> auctions = new List<Auction>();
            foreach (AuctionModel item in dbList)
            {
                auctions.Add(new Auction(item));
            }
            return View(auctions);
        }

        public ActionResult AwardItem(int id) {
            Bid bid = new Bid(BidProcessor.GetBid(id));
            WonItemProcessor.Create(bid.UserId, bid.ItemId);
            AuctionedItemProcessor.AwardItem(id);
            return RedirectToAction("AwardItems");
        }
    }
}
