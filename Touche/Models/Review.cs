﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Touche.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Message { get; set; }
    }
}