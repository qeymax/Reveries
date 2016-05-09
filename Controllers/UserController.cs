using Reveries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reveries.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            
            return View();
        }


       [HttpPost]
       public ActionResult  Index(string name)
        {
            ViewData["Name"] = name;
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {

            return View();
        }
    }
}