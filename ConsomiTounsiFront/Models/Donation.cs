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

        // foreign Key properties
        public Nullable<int> UserId { get; set; }
        public virtual User user { get; set; }

        public Nullable<int> JackpotId { get; set; }
        public virtual Jackpot jackpot { get; set; }

    }
}