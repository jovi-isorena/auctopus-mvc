using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class AuctionModel
    {
        public AuctionedItemModel Item { get; set; }
        public BidModel HighestBid { get; set; }
    }
}
