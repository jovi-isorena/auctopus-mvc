using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class AuctionedItemModel
    {
            public int AuctionedItemId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageURL { get; set; }
            public string Category { get; set; }
            public string BidMethod { get; set; }
            public DateTime AuctionStartDateTime { get; set; }
            public DateTime AuctionEndDateTime { get; set; }
            public double InitialBid { get; set; }
            public string Status { get; set; }
    }
}
