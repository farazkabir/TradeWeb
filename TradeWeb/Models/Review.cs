using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeWeb.Models
{
    public class Review
    {
        public string ReviewId { get; set; }
        public string Content { get; set; }
        public string ReviewerId { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}