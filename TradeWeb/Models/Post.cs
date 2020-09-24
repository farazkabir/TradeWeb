using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeWeb.Models
{
    public class Post
    {
        public string PostId { get; set; }
        public string CoverId { get; set; }
        public string CategoryName { get; set; }
        public string PostDescription { get; set; }
        public string TradeDemands { get; set; }
        public string PostTitle { get; set; }


        public string UserId { get; set; }
        public Media Media { get; set; }
        public ICollection<User> User { get; set; }
        public DateTime Timestamp { get; set; }


    }
}