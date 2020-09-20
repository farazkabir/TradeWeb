using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeWeb.ViewModels
{
    public class FeedbackViewModel
    {
        public string Type { get; set; }
        public string WriterId { get; set; }
        public string WriterName { get; set; }
        public string SubjectId { get; set; }

        public string Timestamp { get; set; }

        public string Content { get; set; }
        public string FilePath { get; set; }
    }
}