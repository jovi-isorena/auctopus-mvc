using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    public class Homepage
    {
        public List<HotItem> HotItems { get; set; }
        public List<Auction> Auctions { get; set; }
    }
}