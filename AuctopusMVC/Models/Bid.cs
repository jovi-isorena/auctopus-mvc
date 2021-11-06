using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    public class Bid
    {
        public Bid() { }
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
}