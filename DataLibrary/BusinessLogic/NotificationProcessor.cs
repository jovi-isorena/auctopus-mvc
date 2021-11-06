using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class NotificationProcessor
    {
        public static int Create(NotificationType type, int userid, int itemid)
        {
            //SET IDENTITY_INSERT [Notification] ON; 
            NotificationModel data = new NotificationModel(type, userid, itemid){};
            string sql = @"insert into [dbo].[Notification] ([UserId], [Message], [Link], [Read]) values (@UserId, @Message, @Link, @Read);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<NotificationModel> LoadNotifications(int userid)
        {
            NotificationModel data = new NotificationModel { UserId = userid };
            string sql = "select * from dbo.[Notification] where [UserId] = @UserId;";
            return SqlDataAccess.LoadDataWhere<NotificationModel>(sql, data);
        }

    }
}
