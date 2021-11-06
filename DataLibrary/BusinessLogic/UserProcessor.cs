using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string firstName, string lastName, string email, string password, double bidpoint, Boolean isAdmin)
        {
            UserModel data = new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Bidpoint = bidpoint,
                IsAdmin = isAdmin
            };
            string sql = @"insert into dbo.[User] (FirstName, LastName, Email, Password, Bidpoint, Status, IsAdmin) values (@FirstName, @LastName, @Email, @Password, @Bidpoint, 'active', @IsAdmin);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UserModel> LoadUsers()
        {
            string sql = "select * from dbo.[User];";
            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        public static UserModel GetUser(string email, string password)
        {
            UserModel data = new UserModel { Email = email, Password = password };
            string sql = "select * from dbo.[User] where [Email] = @Email and [Password] = @Password;";
            return SqlDataAccess.LoadData<UserModel>(sql, data);
        }
    }
}
