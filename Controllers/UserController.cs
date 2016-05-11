﻿using Reveries.ViewModels;
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
                User = userContext.Users.FirstOrDefault(a => a.Username == username )
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

            FormsAuthentication.SetAuthCookie(form.username, true);


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
    }
}