using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeWeb.Models;

namespace TradeWeb.ViewModels
{
    public class ProfileViewModel
    {
        public IEnumerable<FeedbackViewModel> Reviews { get; set; }
        public Review Review { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }
    }
}