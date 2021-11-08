using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class AuctionedItemProcessor
    {
        public static int Create(string name, string description, string url, string category, string bidMethod, DateTime start, DateTime end, double initialBid)
        {
            AuctionedItemModel data = new AuctionedItemModel
            {
                Name = name,
                Description = description,
                ImageURL = url,
                Category = category,
                BidMethod = bidMethod,
                AuctionStartDateTime = start,
                AuctionEndDateTime = end,
                InitialBid = initialBid,
                Status = "Active"    
            };
            string sql = @"insert into [dbo].[AuctionedItem] ([Name], [Description], [ImageURL], [Category], [BidMethod], [AuctionStartDateTime], [AuctionEndDateTime], [InitialBid], [Status]) values (@Name, @Description, @ImageURL, @Category, @BidMethod, @AuctionStartDateTime, @AuctionEndDateTime, @InitialBid, @Status);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int Edit(int id, string name, string description, string url, string category, string bidMethod, DateTime start, DateTime end, double initialBid, string status)
        {
            AuctionedItemModel data = new AuctionedItemModel 
            { 
                AuctionedItemId = id,
                Name = name,
                Description = description,
                ImageURL = url,
                Category = category,
                BidMethod = bidMethod,
                AuctionStartDateTime = start,
                AuctionEndDateTime = end,
                InitialBid = initialBid,
                Status = status
            };
            string sql = @"update [dbo].[AuctionedItem] set [Name] = @Name, [Description] = @Description, [ImageURL] = @ImageURL, [Category] = @Category, [BidMethod] = @BidMethod, [AuctionStartDateTime] = @AuctionStartDateTime, [AuctionEndDateTime] = @AuctionEndDateTime, [InitialBid] = @InitialBid, [Status] = @Status where [AuctionedItemId] = @AuctionedItemId;";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<AuctionedItemModel> LoadAuctionedItems()
        {
            string sql = "select * from dbo.[AuctionedItem] where [Status] = 'active';";
            return SqlDataAccess.LoadData<AuctionedItemModel>(sql);
        }

        public static List<AuctionedItemModel> LoadEndedAuctions()
        {
            string sql = "select * from dbo.AuctionedItem where [AuctionEndDateTime] < CURRENT_TIMESTAMP and [Status] = 'Active';";
            return SqlDataAccess.LoadData<AuctionedItemModel>(sql);
        }

        public static AuctionedItemModel GetAuctionedItem(int id) 
        {
            AuctionedItemModel item = new AuctionedItemModel { AuctionedItemId = id };
            string sql = "select * from dbo.[AuctionedItem] where [AuctionedItemId] = @AuctionedItemId;";
            return SqlDataAccess.LoadData<AuctionedItemModel>(sql, item);
        }

        public static int AwardItem(int id) 
        {
            AuctionedItemModel data = new AuctionedItemModel
            {
                AuctionedItemId = id,
                Status = "Awarded"
            };
            string sql = @"update [dbo].[AuctionedItem] set [Status] = @Status where [AuctionedItemId] = @AuctionedItemId;";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CloseAuction(int id)
        {
            AuctionedItemModel data = new AuctionedItemModel { AuctionedItemId = id };
            string sql = @"update [dbo].[AuctionedItem] set [Status] = 'Closed' where [AuctionedItemId] = @AuctionedItemId";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int Archive(int id)
        {
            AuctionedItemModel data = new AuctionedItemModel
            {
                AuctionedItemId = id,
                Status = "Archived"
            };
            string sql = @"update [dbo].[AuctionedItem] set [Status] = @Status where [AuctionedItemId] = @AuctionedItemId;";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
