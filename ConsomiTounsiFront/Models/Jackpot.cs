using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Jackpot
    {
        [Key]
        public int id { get; set; }
        

        [Required(ErrorMessage = "Name jackpot Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string name { get; set; }


        // foreign Key properties
        public virtual Event @event { get; set; }
        public virtual ICollection<Donation> donations { get; set; }
    }
}