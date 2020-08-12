using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeWeb.Models;

namespace TradeWeb.ViewModels
{
    public class SinglePostViewModel
    {
        public Media Image { get; set; }
        public Post Post { get; set; }

        public string UserName { get; set; }
        public IEnumerable<Media> Media { get; set; }
    }
}