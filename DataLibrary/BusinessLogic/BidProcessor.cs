using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class BidProcessor
    {
        public static int Create(int itemId, int userId, double amount)
        {
            BidModel data = new BidModel
            {
                ItemId = itemId,
                UserId = userId,
                Amount = amount,
                Status = "Active"
            };
            string sql = @"insert into [dbo].[Bid] ([ItemId], [UserId], [Amount], [Status]) values (@ItemId, @UserId, @Amount, @Status);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static BidModel GetHighestBid(int id)
        {
            BidModel data = new BidModel { ItemId = id };
            string sql = @"select top 1 * from [dbo].[Bid] where [ItemId] = @ItemId order by amount desc;";
            return SqlDataAccess.LoadData<BidModel>(sql, data);
        }

        public static BidModel GetBid(int id) 
        {
            BidModel data = new BidModel { Id = id };
            string sql = @"select top 1 * from [dbo].[Bid] where [Id] = @Id;";
            return SqlDataAccess.LoadData<BidModel>(sql, data);
        }

        public static List<int> GetBidders(int itemid)
        {
            BidModel data = new BidModel{ItemId = itemid};
            string sql = @"select distinct([UserId]) from dbo.[Bid] where [ItemId] = " + itemid + ";";

            return SqlDataAccess.LoadData<int>(sql);
        }

        public static List<HotItemModel> GetHotiItems() 
        {
            string sql = @"select top 10 b.[ItemId], 
	            count(distinct UserId) as 'UserCount', 
	            count([Id]) as 'BidCount', 
	            max([Amount]) as 'HighestBid'
                from dbo.[Bid] b
                group by b.[ItemId]
                order by [BidCount] desc;";
            return SqlDataAccess.LoadData<HotItemModel>(sql);
        }
    }
}
