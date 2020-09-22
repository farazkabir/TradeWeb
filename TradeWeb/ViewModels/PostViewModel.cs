using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWeb.Models;

namespace TradeWeb.ViewModels
{
    public class PostViewModel
    {
        public string PostId { get; set; }
        public string CoverId { get; set; }
        public string CategoryName { get; set; }

       
        public string UserId { get; set; }
        public string PostDescription { get; set; }
        public string TradeDemands { get; set; }
        public bool UserView { get; set; }
        public HttpPostedFileBase Cover { get; set; }
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
        public IEnumerable<Post> Posts { get; set; }

        public Comment Comment { get; set; }
        public ICollection<AdPostViewModel> AdPost { get; set; }
        public ICollection<UserxViewModel> Users { get; set; }
        public ICollection<Comment> Comments { get; set; }

        ///  public List<string> PostInfo { get; set; }


    }
}