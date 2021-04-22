using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Coupon
    {
        public long Id { get; set; }
        public String Code { get; set; }
        public Double Promo { get; set; }
        public List<Product> Products { get; set; }
        /*[ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }*/
    }
}