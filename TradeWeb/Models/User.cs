using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace TradeWeb.Models
{
    public class User
    {
        public int Id { get; set; }
      //  public string UserId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
       // public string MediaId { get; set; }
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

      
        public virtual ApplicationUser ApplicationUser { get; set; }
    //   [ForeignKey("Media")]
       public string MediaId { get; set; }
        public virtual Media Media { get; set; }

        
    }

   
}