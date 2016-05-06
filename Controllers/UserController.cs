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
       public ActionResult Index(string username)
        {
            
            return View();
        }
    }
}