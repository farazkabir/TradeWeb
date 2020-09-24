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
                                       Description = post.PostDescription,
                                       TradeDemands = post.TradeDemands
                                   }
                               ).Where(m => m.CoverId == m.MediaId);
               

                PM.AdPost = SearchedPosts.ToList();
                //var resultu = _context.Users
                //.Where(u => u.Name.Contains(SearchQuery)
                //|| u.ApplicationUser.Email.Contains(SearchQuery))
                // .Join(_context.Media,
                //                   user => user.MediaId,
                //                   media => media.MediaId,
                //                   (user, media) => new UserxViewModel
                //                   {
                //                       UserId = user.UserId,
                //                       MediaId = media.MediaId,
                //                       Name = user.Name,
                //                       FilePath = media.FilePath,

                //                   }
                //               );
                //PM.Users = resultu.ToList();

                return View(PM);


            }

           // var User = new UserxViewModel();
            var result = _context.Users
                .Where(u => u.Name.Contains(SearchQuery))

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
            var Comments= _context.Comment.Where(c=>c.PostId == id);
            
            
            var SinglePost = new SinglePostViewModel();
            
            SinglePost.Post = Post;
            SinglePost.UserName = User.Name;

            SinglePost.Media = Media.ToList();



           FeedbackViewModel PM = new FeedbackViewModel();
            var comments = _context.Comment
                               .Join(
                                   _context.Post,
                                   comment => comment.PostId,
                                   post => post.PostId,
                                   (comment, post) => new FeedbackViewModel
                                   {
                                       SubjectId = post.PostId,
                                       //MediaId = media.MediaId,
                                       //CoverId = post.CoverId,
                                       WriterId = comment.UserId,
                                       WriterName = _context.Users.FirstOrDefault(u => u.UserId == comment.UserId).Name,
                                       FilePath = _context.Media.FirstOrDefault(m=> m.MediaId == _context.Users.FirstOrDefault(u => u.UserId == comment.UserId).MediaId).FilePath,
                                       Content =comment.Content,
                                       Timestamp=comment.Timestamp.ToString(),
                                       Type = "COMMENT"
                                   }
                               );
            Console.WriteLine("rendered");
            SinglePost.Comments = comments.ToList();



            return View(SinglePost);
        }

        [HttpPost]
        public ActionResult AddComment(Comment Comment)
        {
            string PostId;


            if (ModelState.IsValid)
            {
                Comment C = new Comment();
                C.CommentId = Guid.NewGuid().ToString();
                //Comment.Timestamp = DateTime.Now;
                C.Content = Comment.Content;
                C.PostId = Comment.PostId;
                C.UserId = Comment.UserId;
                C.Timestamp = DateTime.Now;



                _context.Comment.Add(C);
               
                _context.SaveChanges();

            

            }

            PostId = Comment.PostId;
            return RedirectToAction("Index",  // <-- ActionMethod
               "Post", new { id = PostId });
        }
        public ActionResult MyPosts(string id)
        {

            PostViewModel PM = new PostViewModel();
            var a = _context.Media
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
                                       UserName = _context.Users.FirstOrDefault(u => u.UserId == post.UserId).Name,
                                       FilePath = media.FilePath,
                                       Description = post.PostDescription,
                                       TradeDemands = post.TradeDemands
                                   }
                               ).Where(m => m.CoverId == m.MediaId).Where(u=> u.UserId == id);


            PM.AdPost = a.ToList();


            return View(PM);
            
        }

        public ActionResult DeletePost(string id)
        {
            var itemToRemove = _context.Post.SingleOrDefault(p => p.PostId == id); //returns a single item.

            var postUserId = _context.Post.SingleOrDefault(p => p.PostId == id).UserId;
            var userId = _context.Users.SingleOrDefault(u => u.UserId == postUserId).UserId;

            if (itemToRemove != null)
            {
                _context.Post.Remove(itemToRemove);
                _context.SaveChanges();
            }
            
            return RedirectToAction("MyPosts",  // <-- ActionMethod
              "Post", new { id = userId });
        }
    }
}