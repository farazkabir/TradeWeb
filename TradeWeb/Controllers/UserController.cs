using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWeb.Models;
using TradeWeb.ViewModels;


namespace TradeWeb.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController(){
            
            _context = new ApplicationDbContext();
        
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: User
        public ActionResult Details(int id)
        {
            var Users = _context.Users.SingleOrDefault(u => u.UserId == id.ToString());
            return View();
        }
        public ActionResult UserPage(string id)
          
        {
            var Users = _context.Users.ToList();
            @ViewBag.ID = id;
            //var id = _context.Users;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserxViewModel User)
        {

            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(User.ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(User.ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = "";
            string Id=User.MediaId = Guid.NewGuid().ToString();

            //Its Create complete path to store in server.  
            User.FilePath = UploadPath + Id + FileName;
            User.MediaId = Id;
            //To copy and save file into server.  
            User.ImageFile.SaveAs(Server.MapPath("~/Images/") + User.FilePath);
            User u = new User();
            u.UserId = User.UserId;
            u.Name = User.Name;
            u.PhoneNumber = User.PhoneNumber;
            u.MediaId = User.MediaId;
            u.Id = User.Id;
            u.Address = User.Address;

            Media img = new Media();
            img.MediaId=User.MediaId;
            img.FilePath = User.FilePath;


            _context.Media.Add(img);

            _context.Users.Add(u);


            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult EditUser(string id)
        {

            var User = _context.Users.SingleOrDefault(user => user.UserId == id);
            var MediaId = User.MediaId;
            var Media = _context.Media.SingleOrDefault(m => m.MediaId == MediaId);
            var u = new UserxViewModel();
            u.UserId = User.UserId;
            u.Name = User.Name;
            u.PhoneNumber = User.PhoneNumber;
            u.Address = User.Address;
            u.MediaId = User.MediaId;
            u.Id = User.Id;
            u.FilePath = Media.FilePath;


            if (User == null)
                return HttpNotFound();
            return View(u);
        }
        [HttpPost]
        public ActionResult EditProfilePicture(UserxViewModel User)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(User.ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(User.ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = "";
            string Id = User.MediaId = Guid.NewGuid().ToString();

            //Its Create complete path to store in server.  
            User.FilePath = UploadPath + Id + FileName;
            User.MediaId = Id;
            //To copy and save file into server.  
            User.ImageFile.SaveAs(Server.MapPath("~/Images/") + User.FilePath);
          
            Media img = new Media();
            img.MediaId = User.MediaId;
            img.FilePath = User.FilePath;


            _context.Media.Add(img);
            var EditUser = _context.Users.SingleOrDefault(user => user.UserId == User.UserId);

            EditUser.MediaId = User.MediaId;
            _context.SaveChanges();
            return RedirectToAction("EditUser",  // <-- ActionMethod
              "User", new { id = User.UserId });

        }


        [HttpPost]
        public ActionResult EditName(UserxViewModel User)
        {
            var EditUser = _context.Users.SingleOrDefault(user => user.UserId == User.UserId);

            EditUser.Name = User.Name;
            
            _context.SaveChanges();
          //  var id = User.Id;
            return RedirectToAction("EditUser",  // <-- ActionMethod
               "User", new { id = User.UserId });
            

        }
        [HttpPost]
        public ActionResult EditPhone(UserxViewModel User)
        {
            var EditUser = _context.Users.SingleOrDefault(user => user.UserId == User.UserId);

            EditUser.PhoneNumber = User.PhoneNumber;

            _context.SaveChanges();
            //  var id = User.Id;
            return RedirectToAction("EditUser",  // <-- ActionMethod
               "User", new { id = User.UserId });


        }
        [HttpPost]
        public ActionResult EditAddress(UserxViewModel User)
        {
            var EditUser = _context.Users.SingleOrDefault(user => user.UserId == User.UserId);

            EditUser.Address = User.Address;

            _context.SaveChanges();
            //  var id = User.Id;
            return RedirectToAction("EditUser",  // <-- ActionMethod
               "User", new { id = User.UserId });


        }

        [HttpPost]
        public ActionResult AddPost(PostViewModel Post)
        {



            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                Post.PostId = Guid.NewGuid().ToString();
                foreach (HttpPostedFileBase file in Post.files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ImageId = Guid.NewGuid().ToString();

                      
                        Media img = new Media();
                        img.MediaId =ImageId;
                       // img.FilePath = ImageId;
                        img.PostId = Post.PostId;
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Images/") +ImageId+ InputFileName);

                        img.FilePath = ImageId + InputFileName;
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        _context.Media.Add(img);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = Post.files.Count().ToString() + " files uploaded successfully.";
                    }

                }
                string FileName = Path.GetFileNameWithoutExtension(Post.Cover.FileName);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(Post.Cover.FileName);

                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                var CoverId = Guid.NewGuid().ToString();
                Media cover = new Media();
                cover.MediaId = CoverId;
               // cover.FilePath = CoverId;
                cover.PostId = Post.PostId;
                var SavePath = Path.Combine(Server.MapPath("~/Images/") + CoverId + FileName);
                cover.FilePath =CoverId+FileName;
                //Save file to server folder  
                Post.Cover.SaveAs(SavePath);
                _context.Media.Add(cover);
                Post p = new Post();
                p.PostId = Post.PostId;
                p.UserId = Post.UserId;
                p.CoverId = CoverId;
                p.CategoryName = Post.CategoryName;
                p.PostDescription = Post.PostDescription;
                p.TradeDemands = Post.TradeDemands;
                _context.Post.Add(p);
                _context.SaveChanges();



            }


            return RedirectToAction("Index",  // <-- ActionMethod
               "Home");
        }


        public ActionResult UserProfile(string id)
        {
            var Profile = new ProfileViewModel();
            Profile.UserId = id;
            Profile.FilePath = _context.Media.SingleOrDefault(m => m.MediaId == _context.Users.FirstOrDefault(u => u.UserId == id).MediaId).FilePath;
            var userDb = _context.Users.SingleOrDefault(u => u.UserId == id);
            Profile.Name = userDb.Name;
            Profile.Address = userDb.Address;
            Profile.PhoneNumber = userDb.PhoneNumber;
            //Profile.FilePath = _context.Media.FirstOrDefault(m => m.MediaId == _context.Users.FirstOrDefault(u => u.UserId == id).MediaId).FilePath;
            FeedbackViewModel PM = new FeedbackViewModel();
            var reviews = _context.Review
                               .Join(
                                   _context.Users,
                                   review => review.ReviewerId,
                                   user => user.UserId,
                                   (review, user) => new FeedbackViewModel
                                   {
                                       SubjectId = review.UserId,
                                       //MediaId = media.MediaId,
                                       //CoverId = post.CoverId,
                                       WriterId = review.ReviewerId,
                                       WriterName = _context.Users.FirstOrDefault(u => u.UserId == review.ReviewerId).Name,
                                       FilePath = _context.Media.FirstOrDefault(m => m.MediaId == _context.Users.FirstOrDefault(u => u.UserId == review.ReviewerId).MediaId).FilePath,
                                       Content = review.Content,
                                       Type = "REVIEW"
                                   }
                               );
            Console.WriteLine("rendered");
            Profile.Reviews = reviews.ToList();
            return View(Profile);
        }
        [HttpPost]
        public ActionResult AddReview(Review Review)
        {
            string UserId;


            if (ModelState.IsValid)
            {
                Review R = new Review();
                R.ReviewId = Guid.NewGuid().ToString();
                //Comment.Timestamp = DateTime.Now;
                R.Content = Review.Content;
                R.ReviewerId = Review.ReviewerId;
                R.UserId = Review.UserId;
                R.Timestamp = DateTime.Now;



                _context.Review.Add(R);

                _context.SaveChanges();



            }

            UserId = Review.UserId;
            return RedirectToAction("UserProfile",  // <-- ActionMethod
               "User", new { id = UserId });
        }


        /*   [HttpPost]
           public ActionResult UploadFiles()
           {
               bool isSuccess = false;
               string serverMessage = string.Empty;
               Guid guid = Guid.NewGuid();
               string str = guid.ToString();
               Media img = new Media();
               img.MediaId = str;
               var fileOne = Request.Files[0] as HttpPostedFileBase;
            //   var fileTwo = Request.Files[1] as HttpPostedFileBase;
               string uploadPath = Server.MapPath("~/Uploads/") +str+ Path.GetFileName(fileOne.FileName);/// ConfigurationManager.AppSettings["UPLOAD_PATH"].ToString();
               // string newFileOne = Path.Combine(uploadPath, fileOne.FileName);
               // string newFileTwo = Path.Combine(uploadPath, fileTwo.FileName);
               img.FilePath = uploadPath;

               fileOne.SaveAs(uploadPath);
             //  fileTwo.SaveAs(newFileTwo);

               if (System.IO.File.Exists(uploadPath) )
               {
                   isSuccess = true;
                   serverMessage = img.MediaId;
               }
               else
               {
                   isSuccess = false;
                   serverMessage = "Files upload is failed. Please try again.";
               }
               _context.Media.Add(img);
               return Json(new { IsSucccess = isSuccess, ServerMessage = serverMessage }, JsonRequestBehavior.AllowGet);
           } */

    }
}       