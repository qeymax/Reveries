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
            
            return View(new User {
                Users = context.Users.ToList(),
                Follows = context.Follows.ToList()
            });
        }

       
    }
}