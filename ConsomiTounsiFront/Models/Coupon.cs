using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Coupon
    {
        [Key]
        public long id { get; set; }
        public String Code { get; set; }
        public Double Promo { get; set; }
        public List<Product> product { get; set; }
        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public User user { get; set; }
    }
}