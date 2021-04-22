using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Add
    {
        public long Id  { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        public Double PriceSponsoring { get; set; }
        public float Average { get; set; }
        public String Image { get; set; }
        public int MyProperty { get; set; }
        public String Name { get; set; }
        public enum Type { Product_ADD, Event_ADD };

        [ForeignKey("IdProduct")]
        public int IdProduct { get; set; }
        public Product Prod { get; set; }
        /*[ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }*/

    }
}