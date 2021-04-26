using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Rating
    {
        [Key]
        public long id { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateRating { get; set; }
        public int note { get; set; }
        public String review { get; set; }
        [ ForeignKey("idProduct")]
        public int idProduct { get; set; }
        public Product product { get; set; }

        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public User user { get; set; }

    }
}