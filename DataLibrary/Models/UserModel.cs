using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Bidpoint { get; set; }
        public string HomeAddress { get; set; }
        public DateTime LastLoginAttempt { get; set; }
        public int LoginAttemptCount { get; set; }
        public DateTime LockedUntil { get; set; }
        public string Status { get; set; }
        public Boolean IsAdmin { get; set; }
        
    }
}
