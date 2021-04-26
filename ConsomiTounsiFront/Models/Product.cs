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
        [Key]
        public long id { get; set; }
        public String description { get; set; }
        public String name { get; set; }
        public String image { get; set; }
        public double price { get; set; }
        public String reference { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateProd { get; set; }
        [ForeignKey("idCategory")]
        public int idCategory { get; set; }
        public Category categorie { get; set; }
        public List<Add> add { get; set; }
        public List<Rating> rating { get; set; }
        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public User user { get; set; }

        public Product()
        {
        }
    }
}