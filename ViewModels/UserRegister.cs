using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reveries.ViewModels
{
    public class UserRegister
    {
        [Required]
        public string username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string confirmPassword { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
    }
}