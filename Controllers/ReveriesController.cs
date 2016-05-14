using Reveries.Models;
using Reveries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reveries.Controllers
{
    public class ReveriesController : Controller
    {
        Context ReverieContext = new Context();

        [HttpPost]
        public ActionResult AddComment(int id, string content)
        {
            Comment comment = new Comment();
            comment.Content = content;
            comment.UserId = ReverieContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name).Id;
            comment.ReverieId = id;
            comment.CreateDate = DateTime.Now;
            ReverieContext.Comments.Add(comment);
            ReverieContext.SaveChanges();
            return View (new ReveriesAddComment {
                Comment = comment
            });
        }


        [HttpPost]
        public ActionResult EditComment(int id, string content)
        {
            ReverieContext.Comments.FirstOrDefault(a => a.Id == id).Content = content;
            ReverieContext.SaveChanges();
            return Content("dsrf");
        }
        [HttpPost]
        public ActionResult EditReverie(int id, string content)
        {
            ReverieContext.Reveries.FirstOrDefault(a => a.Id == id).Content = content;
            ReverieContext.SaveChanges();
            return Content("dsrf");
        }

        [HttpPost]
        public ActionResult DeleteReverie(int id)
        {
            ReverieContext.Reveries.Remove(ReverieContext.Reveries.FirstOrDefault(a => a.Id == id));
            ReverieContext.SaveChanges();
            return Content("dsrf");
        }


        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            ReverieContext.Comments.Remove(ReverieContext.Comments.FirstOrDefault(a => a.Id == id));
            ReverieContext.SaveChanges();
            return Content("dsrf");
        }

        [HttpPost]
        public ActionResult Like(int id , int userid)
        {
            Like like = new Like();
            like.UserId = userid;
            like.ReverieId = id;
            ReverieContext.Likes.Add(like);
            ReverieContext.SaveChanges();
            return Content("dsrf");

        }
        [HttpPost]
        public ActionResult Unlike(int id , int userid)
        {
            ReverieContext.Likes.Remove(ReverieContext.Likes.FirstOrDefault(a => a.ReverieId == id && a.UserId == userid));
            ReverieContext.SaveChanges();
            return Content("dsrf");
        }


        public ActionResult Follow(string username , string id)
        {
            var user = ReverieContext.Users.FirstOrDefault(a => a.Username == id);
            var followed = ReverieContext.Users.FirstOrDefault(a => a.Username == username);
            Models.Follow follow = new Models.Follow();
            follow.Follower = user;
            follow.Followed = followed;
            ReverieContext.Follows.Add(follow);
            ReverieContext.SaveChanges(); 
            return Content("no");
        }

        public ActionResult unFollow(string username , string id)
        {
            var user = ReverieContext.Users.FirstOrDefault(a => a.Username == id);
            var followed = ReverieContext.Users.FirstOrDefault(a => a.Username == username);
            ReverieContext.Follows.Remove(ReverieContext.Follows.FirstOrDefault(a => a.FollowerId == user.Id && a.FollowedId == followed.Id));
            ReverieContext.SaveChanges();
            return Content("no");
        }
    }
}