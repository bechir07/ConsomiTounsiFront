using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Donation
    {

        [Key]
        public int id { get; set; }

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double montant { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string jname { get; set; }

        // foreign Key properties
        public Nullable<long> UserId { get; set; }
        public virtual User user { get; set; }

        public int? JackpotId { get; set; }
        public virtual Jackpot jackpot { get; set; }

    }
}