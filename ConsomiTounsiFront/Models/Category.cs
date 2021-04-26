using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Category
    {
        [Key]
        public long id { get; set; }
        public String Name { get; set; }
        public List<Product> product{ get; set; }
    }
}