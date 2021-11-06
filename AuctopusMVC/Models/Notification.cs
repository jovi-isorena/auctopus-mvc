using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{
    
    public class Notification
    {
        public Notification() { }

        public Notification(NotificationModel notif)
        {
            Id = notif.Id;
            UserId = notif.UserId;
            Message = notif.Message;
            Link = notif.Link;
            CreatedOn = notif.CreatedOn;
            Read = notif.Read;
        }
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Read { get; set; }
    }
}