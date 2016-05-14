using Reveries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Reveries.ViewModels
{
    public class UserEditProfile
    {
        [Required]
        public string name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string about { get; set; }
        public string pass { get; set; }
        public string confirmpass { get; set; }
        public string oldpass { get; set; }
        public User user { get; set; }


    }
}