﻿using Reveries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reveries.ViewModels
{
    public class UserIndex
    {
        public User User { get; set; }
        public User ActiveUser { get; set; }
        public string textArea { get; set; }

    }
}