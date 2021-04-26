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
        [Key]
        public long id  { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateEnd { get; set; }
        public Double priceSponsoring { get; set; }
        public float average { get; set; }
        public String Image { get; set; }
        public String name { get; set; }
        public enum type { Product_ADD, Event_ADD };

        [ForeignKey("idProduct")]
        public int idProduct { get; set; }
        public Product prod { get; set; }
        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public User user { get; set; }

    }
}