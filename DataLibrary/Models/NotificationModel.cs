using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public enum NotificationType
    {
        LoseBid,
        WonBid,
        OutBid,
        ItemAwarded
    }
    
    public class NotificationModel
    {
        public NotificationModel() { }

        public NotificationModel(NotificationType type, int userid, int itemid)
        {
            if (type == NotificationType.LoseBid)
            {
                UserId = userid;
                Message = "Unfortunaly, you didn't get the item. The auction for item # " + itemid + " had been closed.";
                Link = "~/Auction/Room/" + itemid;

            }
            else if (type == NotificationType.WonBid)
            {
                UserId = userid;
                Message = "Congratulations! You won item # " + itemid + ". The auction for item # " + itemid + " had been closed. The item will be awarded to your account within 24 hours.";
                Link = "~/Auction/Room/" + itemid;
            }
            else if (type == NotificationType.OutBid)
            {
                UserId = userid;
                Message = "Quick! Someone outbid you on item # " + itemid + ". Click here to make a new bid.";
                Link = "~/Auction/Room/" + itemid;
            }
            else if (type == NotificationType.ItemAwarded)
            {
                UserId = userid;
                Message = "[NOTICE] Item # " + itemid + " has been successfully awarded to your account. Click here to view your awarded items.";
                Link = "~/Items/Awarded/" + itemid;
            }

            Read = false;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Read { get; set; }
    }
}
