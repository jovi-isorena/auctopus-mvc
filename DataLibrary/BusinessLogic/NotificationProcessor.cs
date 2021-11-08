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

        public static NotificationModel GetNotification(int id)
        {
            NotificationModel data = new NotificationModel{Id = id};
            string sql = @"select * from [dbo].[Notification] where [Id] = @Id";
            return SqlDataAccess.LoadData<NotificationModel>(sql,data);
        }

        public static List<NotificationModel> LoadNotifications(int userid)
        {
            NotificationModel data = new NotificationModel { UserId = userid };
            string sql = "select * from dbo.[Notification] where [UserId] = @UserId;";
            return SqlDataAccess.LoadDataWhere<NotificationModel>(sql, data);
        }

        public static List<NotificationModel> GetUnreadNotifications(int userid)
        {
            NotificationModel data = new NotificationModel { UserId = userid };
            string sql = "select * from dbo.[Notification] where [UserId] = @UserId AND [Read] = 0 ORDER BY [CreatedOn] DESC;";
            return SqlDataAccess.LoadDataWhere<NotificationModel>(sql, data);
        }

        public static int GetUnreadNotificationsCount(int userid)
        {
            NotificationModel data = new NotificationModel { UserId = userid };
            string sql = "select * from dbo.[Notification] where [UserId] = @UserId AND [Read] = 0;";
            return SqlDataAccess.LoadDataWhere<NotificationModel>(sql, data).Capacity;
        }

        public static void ReadNotification(int id)
        {
            NotificationModel data = new NotificationModel { Id = id };
            string sql = "update dbo.[Notification] set [Read] = 1 where [Id] = @Id;";
            SqlDataAccess.SaveData(sql, data);
        }
    }
}
