using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWeb.Models;
using TradeWeb.ViewModels;

namespace TradeWeb.Controllers
{
    public class PostController : Controller
    {

        private ApplicationDbContext _context;

        public PostController()
        {

            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            string SearchQuery = form["Search"];
            bool IsUser = Convert.ToBoolean(form["IsUser"].Split(',')[0]);
            PostViewModel PM = new PostViewModel();
            if (!IsUser)
            {
                var SearchedPosts = _context.Post
                    .Where(p => p.CategoryName.Contains(SearchQuery) 
                            || p.PostDescription.Contains(SearchQuery))
                    .Join(_context.Media,
                                   post => post.PostId,
                                   media => media.PostId,
                                   ( post,media) => new AdPostViewModel
                                   {
                                       PostId = post.PostId,
                                       MediaId = media.MediaId,
                                       CoverId = post.CoverId,
                                       UserId = post.UserId,
                                       UserName = _context.Users.FirstOrDefault(u => u.UserId == post.UserId).Name,
                                       FilePath = media.FilePath,
                                       Description = post.PostDescription
                                   }
                               ).Where(m => m.CoverId == m.MediaId);
               

                PM.AdPost = SearchedPosts.ToList();

                return View(PM);


            }

           // var User = new UserxViewModel();
            var result = _context.Users
                .Where(u => u.Name.Contains(SearchQuery)
                || u.ApplicationUser.Email.Contains(SearchQuery))
                 .Join(_context.Media,
                                   user => user.MediaId,
                                   media => media.MediaId,
                                   (user, media) => new UserxViewModel
                                   {
                                       UserId = user.UserId,
                                       MediaId = media.MediaId,
                                       Name = user.Name,
                                       FilePath = media.FilePath,
                                      
                                   }
                               ) ;
            PM.Users = result.ToList();
            // string country = form["Country"];
            return View(PM);
        }
        // GET: Post
        public ActionResult Index(string id )
        {
            var Post = _context.Post.SingleOrDefault(p => p.PostId == id);
            var Media = _context.Media.Where(m => m.PostId == id);
            var User = _context.Users.SingleOrDefault(u => u.UserId == Post.UserId);
            
            
            var SinglePost = new SinglePostViewModel();
            
            SinglePost.Post = Post;
            SinglePost.UserName = User.Name;

            SinglePost.Media = Media.ToList();

            
            
            return View(SinglePost);
        }
    }
}