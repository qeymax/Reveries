﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reveries.Models
{
    [Table("Likes")]
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReverieId { get; set; }


        public User User { get; set; }

        public Reverie Reverie { get; set; }

    }
}