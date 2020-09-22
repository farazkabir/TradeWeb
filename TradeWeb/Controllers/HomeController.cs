using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWeb.Models;
using TradeWeb.ViewModels;

namespace TradeWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {

            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            // ViewBag.Posts = _context.Post.ToList();

            PostViewModel PM = new PostViewModel();
            var a= _context.Media
                               .Join(
                                   _context.Post,
                                   media => media.PostId,
                                   post => post.PostId,
                                   (media, post) => new AdPostViewModel
                                   {
                                       PostId = post.PostId,
                                       MediaId = media.MediaId,
                                       CoverId = post.CoverId,
                                       UserId = post.UserId,
                                       UserName = _context.Users.FirstOrDefault(u=> u.UserId == post.UserId).Name,
                                       FilePath = media.FilePath,
                                       Description = post.PostDescription,
                                       TradeDemands= post.TradeDemands
                                   }
                               ).Where(m=> m.CoverId == m.MediaId);
               Console.WriteLine("rendered");
            //  return PartialView(Posts);
            /*  PostViewModel PM = new PostViewModel();
 PM.Posts = _context.Post.ToList();
 foreach(var p in PM.Posts)
 {
     var d = _context.Media.SingleOrDefault(a => a.MediaId == p.CoverId);
     PM.PostInfo.Add(d.FilePath);
 }
 */
            //  var a = _context.Post.Include(p => p.Media)
            PM.AdPost = a.ToList();
           

            return View(PM);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}