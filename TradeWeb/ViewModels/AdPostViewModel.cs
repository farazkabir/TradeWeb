using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeWeb.ViewModels
{
    public class AdPostViewModel
    {
        public string MediaId { get; set; }
        public string CoverId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string TradeDemands { get; set; }

        public string PostId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

    }
}