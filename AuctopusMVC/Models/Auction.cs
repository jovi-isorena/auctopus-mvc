using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    public class Auction
    {
        public Auction() { }
        public Auction(DataLibrary.Models.AuctionModel auction)
        {
            // TODO: Complete member initialization
            Item = new AuctionedItem(auction.Item);
            if(auction.HighestBid != null) 
                HighestBid = new Bid(auction.HighestBid);
        }
        [Display(Name="Item")]
        public AuctionedItem Item { get; set; }
        [Display(Name="Highest Bid")]
        public Bid HighestBid { get; set; }
        public Bid NewBid { get; set; }

    }
}