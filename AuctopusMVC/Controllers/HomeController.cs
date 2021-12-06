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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string category, string query)
        {
            List<HotItemModel> hotItemsFromDb = BidProcessor.GetHotiItems();
            List<HotItem> hotItems = new List<HotItem>();
            foreach (var hotItem in hotItemsFromDb)
            {
                hotItems.Add(new HotItem(hotItem.BidCount, hotItem.UserCount, hotItem.HighestBid, hotItem.ItemId));
            }

            List<AuctionModel> dbList = AuctionProcessor.LoadAuctions(category, query);
            List<Auction> auctions = new List<Auction>();
            foreach (AuctionModel item in dbList)
            {
                auctions.Add(new Auction(item));
            }
            Homepage homeModel = new Homepage();
            homeModel.HotItems = hotItems;
            homeModel.Auctions = auctions;
            return View(homeModel);
        }

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid) 
            {
                DataLibrary.Models.UserModel user = UserProcessor.GetUser(login.Email, login.Password);
                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    Session["Email"] = user.Email;
                    Session["FirstName"] = user.FirstName;
                    Session["LastName"] = user.LastName;
                    Session["IsAdmin"] = user.IsAdmin;
                    return RedirectToAction("Index");
                }
                else 
                {
                    ViewBag.Message = "Email and/or Password incorrect!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Register";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                int recordCreated = UserProcessor.CreateUser(u.FirstName, u.LastName, u.Email, u.Password, 0, false);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
