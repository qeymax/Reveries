using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reveries.Models;

namespace Reveries.ViewModels
{
    public class User
    {
        public List<Reveries.Models.User> Users { get; set; }
        public List<Follow> Follows { get; set; }
    }
}