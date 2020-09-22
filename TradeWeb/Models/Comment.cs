using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeWeb.Models
{
    public class Comment
    {
        public string CommentId { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}