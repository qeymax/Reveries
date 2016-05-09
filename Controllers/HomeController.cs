using Reveries.Models;
using Reveries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reveries.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            
            return View(new HomeIndex {
                reveries = context.Reveries.ToList()
            });
        }
        [HttpPost]
        public ActionResult Search(string username)
        {
            if (String.IsNullOrEmpty(username))
              return  RedirectToRoute("Home");
            return View(new HomeSearch {
                Users = context.Users.Where(a => a.Username.Contains(username)).ToList()
            });
        }


    }
}