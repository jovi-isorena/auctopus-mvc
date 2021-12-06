using DataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    public class Bid
    {
        public Bid() {
            Id = 0;
            ItemId = 0;
            UserId = 0;
            Amount = 0;
            Status = String.Empty;
        }
        public Bid(DataLibrary.Models.BidModel b) {
            Id = b.Id;
            ItemId = b.ItemId;
            UserId = b.UserId;
            Amount = b.Amount;
            Status = b.Status;
        }
		public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Bid Amount")]
        public double Amount { get; set; } 
        public string Status { get; set; }


    }
    public class HotItem
    {
        public HotItem() { }
        public HotItem(int bidCount, int userCount, double highestBid, int item) 
        {
            BidCount = bidCount;
            UserCount = userCount;
            HighestBid = highestBid;
            Item = new AuctionedItem(AuctionedItemProcessor.GetAuctionedItem(item));
        }

        public int BidCount { get; set; }
        public int UserCount { get; set; }
        public double HighestBid { get; set; }
        public AuctionedItem Item {get; set;}
    }
}