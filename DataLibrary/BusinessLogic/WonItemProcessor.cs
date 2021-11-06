using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class WonItemProcessor
    {
        public static int Create(int userid, int itemid)
        {
            WonItemModel data = new WonItemModel
            {
                UserId = userid,
                ItemId = itemid,
                Status = "Awarded"
            };
            string sql = @"SET IDENTITY_INSERT [WonItem] ON; insert into [dbo].[WonItem] ([Id], [UserId], [ItemId], [Status]) values (@Id, @UserId, @ItemId, @Status);";
            return SqlDataAccess.SaveData(sql, data);
        }

        
    }
}
