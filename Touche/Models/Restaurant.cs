using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Touche.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [AllowHtml]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string About { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }

    }
}