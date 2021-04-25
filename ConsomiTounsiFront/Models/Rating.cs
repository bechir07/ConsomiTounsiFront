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
        public DateTime DateRating { get; set; }
        public int Note { get; set; }
        public String Review { get; set; }
        [ ForeignKey("IdProduct")]
        public int IdProduct { get; set; }
        public Product Product { get; set; }

        [ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }

    }
}