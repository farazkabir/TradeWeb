using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeWeb.Migrations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TradeWeb.Models;

namespace TradeWeb.ViewModels
{
    public class UserxViewModel
    {
        //public User User { get; set; }
    //    public ApplicationUser ApplicationUser { get; set; }

       // public Media Media { get; set; 
        public string UserId { get; set; }
        public string MediaId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }


    }
}