using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Category
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public List<Product> Products { get; set; }
    }
}