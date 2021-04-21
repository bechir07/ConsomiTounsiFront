using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Chariot
    {
        [Key]
        public int id { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double totalp { get; set; }

        // foreign Key properties
        public virtual Event @event { get; set; }
        
    }
}