using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }
    public class HotItemModel
    {
        public int ItemId { get; set; }
        public int UserCount { get; set; }
        public int BidCount { get; set; }
        public double HighestBid { get; set; }
        
    }
}
