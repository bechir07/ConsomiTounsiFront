using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Product
    {
        public long Id { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public String Image { get; set; }
        public double Price { get; set; }
        public String Reference { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }
        [ForeignKey("IdCategory")]
        public int IdCategory { get; set; }
        public Category Categorie { get; set; }
        public List<Add> Add { get; set; }
        public List<Rating> Rating { get; set; }
        /*[ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }*/
    }
}