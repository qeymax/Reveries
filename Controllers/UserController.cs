using Reveries.Models;
using Reveries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Reveries.Controllers
{
    public class UserController : Controller
    {
        Context userContext = new Context();
        // GET: User
        public ActionResult Index(string username)
        {
            
            return View(new UserIndex {
                User = userContext.Users.FirstOrDefault(a => a.Username == username ),
                ActiveUser = userContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name)
            });
        }

        [HttpPost]
        public ActionResult Index(HomeIndex home)
        {
            string reverie = home.textArea;
            if (String.IsNullOrWhiteSpace(reverie))
                return RedirectToRoute("User" , new { username = User.Identity.Name});
            else
            {
                Reverie reverieObj = new Reverie();
                reverieObj.Content = reverie;
                reverieObj.CreateDate = DateTime.Now;
                reverieObj.User = userContext.Users.ToList().FirstOrDefault(a => a.Username == User.Identity.Name);
                userContext.Reveries.Add(reverieObj);
                userContext.SaveChanges();
                return RedirectToRoute("User", new { username = User.Identity.Name });
            }
        }

        [HttpPost]
        public ActionResult UserReveries(string username , int skip)
        {
            if (userContext.Users.FirstOrDefault(a => a.Username == username).Reveries.Count <= skip)
                return Content("End of Reveries");
            return View(new UserUserReveries {
                Reveries = userContext.Reveries.Where(a => a.User == userContext.Users.FirstOrDefault(b => b.Username == username)).OrderByDescending(a => a.Id).Skip(skip).Take(8).ToList()
            });
        }


        [HttpPost]
        public ActionResult EditProfile(UserEditProfile edit , HttpPostedFileBase ProfileUpload , HttpPostedFileBase CoverUpload)
        {
            var user = userContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name);
            user.Name = edit.name;
            user.Email = edit.email;
            user.About = edit.about;    
            if(!String.IsNullOrWhiteSpace(edit.pass))
            {
                if (edit.pass != edit.confirmpass || !user.CheckPassword(edit.oldpass))
                    ModelState.AddModelError("Password", "Passwords don't Match or, incorrect Password !!");
                else
                    user.SetPassword(edit.pass);
            }
            if (ProfileUpload != null)
            {
                string name = User.Identity.Name + ".png";
                string ProfilePath = System.IO.Path.Combine(
                                       Server.MapPath("~/img/Profile/"), name);
                ProfileUpload.SaveAs(ProfilePath);
                user.ProfilePic = name;
            }

            if (CoverUpload != null)
            {
                string name = User.Identity.Name + ".png";
                string CoverPath = System.IO.Path.Combine(
                                       Server.MapPath("~/img/Cover"),name);
                CoverUpload.SaveAs(CoverPath);
                user.CoverPic = name;
            }

            if (!ModelState.IsValid)
            {
                edit.user = userContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name);
                return View(edit);
            }
            userContext.SaveChanges();
            edit.user = userContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name);
            return View(edit);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(new UserEditProfile
            {
                user = userContext.Users.FirstOrDefault(a => a.Username == User.Identity.Name)
            });
        }


        public ActionResult Login()
        {
            return View(new UserLogin { });
        }
        [HttpPost]
        public ActionResult Login(UserLogin form, string ReturnUrl)
        {
            var user = userContext.Users.FirstOrDefault(u => u.Username == form.username);
            if (user == null)
                Reveries.Models.User.FakeHash();

            if (user == null || !user.CheckPassword(form.password))
                ModelState.AddModelError("Username", "Username or Password is incorrect!");

            if (!ModelState.IsValid)
                return View(form);
            bool rem = false;
            if (form.remember == "on")
                rem = true;

            FormsAuthentication.SetAuthCookie(form.username, rem);


            if (!string.IsNullOrWhiteSpace(ReturnUrl))
                return Redirect(ReturnUrl);

            return RedirectToRoute("Home");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister form)
        {
            var user = userContext.Users.FirstOrDefault(u => u.Username == form.username);
            if (user != null)
            {
                ModelState.AddModelError("Username", "Username Already Exists.");
            }
            if(form.password != form.confirmPassword)
                ModelState.AddModelError("Password", "Passwords don't match!");
            if (form.gender == "")
                ModelState.AddModelError("Gender", "Please Choose a gender!");
            if (!ModelState.IsValid)
                return View(form);
            User newuser = new User();
            newuser.Username = form.username;
            newuser.Email = form.email;
            newuser.Name = form.name;
            newuser.SetPassword(form.password);
            newuser.Gender = form.gender;
            newuser.About = null;
            newuser.CoverPic = "default-cover.png";
            newuser.BirthDate = form.birthDate;
            newuser.RegisterDate = DateTime.Now;
            if (form.gender == "1")
                newuser.ProfilePic = "tom.jpg";
            else
                newuser.ProfilePic = "nan.jpg";
            userContext.Users.Add(newuser);
            userContext.SaveChanges();
            return RedirectToRoute("RegisterComplete");
        }

        public ActionResult RegisterComplete()
        {
            return View();
        }
    }
}