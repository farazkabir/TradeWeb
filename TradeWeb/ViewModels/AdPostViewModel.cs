using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeWeb.ViewModels
{
    public class AdPostViewModel
    {
        public string MediaId { get; set; }
        public string CoverId { get; set; }
        public string FilePath { get; set; }
        [Required]
        public string Description { get; set; }
        public string TradeDemands { get; set; }

        public string PostId { get; set; }
       
        public string PostTitle { get; set; }
        public string UserDp { get; set; }
        public string UserName { get; set; }
        public string Timestamp { get; set; }
        public string UserId { get; set; }

    }
}