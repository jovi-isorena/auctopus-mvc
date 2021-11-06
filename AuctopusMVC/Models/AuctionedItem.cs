using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    public class AuctionedItem
    {
        public AuctionedItem() { }
        public AuctionedItem(DataLibrary.Models.AuctionedItemModel model)
        {
            this.AuctionedItemId = model.AuctionedItemId;
            this.Name = model.Name;
            this.Description = model.Description;
            this.ImageURL = model.ImageURL;
            this.Category = model.Category;
            this.BidMethod = model.BidMethod;
            this.AuctionStartDate = model.AuctionStartDateTime.Date;
            this.AuctionStartTime = model.AuctionStartDateTime;
            this.AuctionEndDate = model.AuctionEndDateTime.Date;
            this.AuctionEndTime = model.AuctionEndDateTime;
            this.InitialBid = model.InitialBid;
            this.Status = model.Status;
        }   
        public int AuctionedItemId { get; set; }
        [Required]
        [Display(Name="Item Name")]
        [StringLength(255, ErrorMessage="{0} must be {2} - {1} characters.", MinimumLength=6)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Item Description")]
        [StringLength(255, ErrorMessage="{0} must be {2} - {1} characters.", MinimumLength=6)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name="Item Image")]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }
        [Required(ErrorMessage="Please select a category for this item.")]
        public string Category { get; set; }
        [Required]
        [Display(Name="Bid Method")]
        public string BidMethod { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AuctionStartDate { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime AuctionStartTime { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AuctionEndDate { get; set; }
        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime AuctionEndTime { get; set; }
        [Required]
        [Display(Name="Initial Bid")]
        [DataType(DataType.Currency)]
        public double InitialBid { get; set; }
        public string Status { get; set; }

    }
    
}