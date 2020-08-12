using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TradeWeb.ViewModels;

namespace TradeWeb.Models
{
    public class Media
    {

        public int Id { get; set; }
      //  public string MediaId { get; set; }
        //  public string UserId { get; set; }
        public string FilePath { get; set; }
        //   public string UserId { get; set; }


       

        [Key]
        public string MediaId { get; set; }

        public ICollection<User> User { get; set; }
        public string PostId { get; set; }
        public ICollection<Post> Post { get; set; }
        

        //  [ForeignKey("User")]
        //public string UserId { get; set; }
        //public virtual User User { get; set; }



    }
}