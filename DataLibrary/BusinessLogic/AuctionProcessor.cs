using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class AuctionProcessor
    {
        public static List<AuctionModel> LoadAuctions() 
        {
            List<AuctionModel> auctions = new List<AuctionModel> { };
            string sql = "select * from dbo.[AuctionedItem] where [Status] = 'active';";
            List<AuctionedItemModel> items =  SqlDataAccess.LoadData<AuctionedItemModel>(sql);
            
            foreach (AuctionedItemModel item in items)
            {
                auctions.Add(new AuctionModel { 
                    Item = item,
                    HighestBid = BidProcessor.GetHighestBid(item.AuctionedItemId)
                });
            }

            return auctions;
        }



        public static List<AuctionModel> LoadEndedAuctions()
        {
            string sql = "select * from dbo.[AuctionedItem] where [AuctionEndDateTime] > GETDATE() and [Status] = 'active';";
            List<AuctionedItemModel> items = SqlDataAccess.LoadData<AuctionedItemModel>(sql);
            List<AuctionModel> auctions = new List<AuctionModel> { };
            foreach(AuctionedItemModel item in items)
            {
                auctions.Add(new AuctionModel { 
                    Item = item,
                    HighestBid = BidProcessor.GetHighestBid(item.AuctionedItemId)
                });
            }
            return auctions;
        }
    }
}
