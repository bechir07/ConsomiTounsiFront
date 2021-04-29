using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Date Evenement")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateev { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        
        [Required(ErrorMessage = "Name Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string name { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string imagename { get; set; }

        [Required(ErrorMessage = "Place Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string lieu { get; set; }
        
        [Range(0, int.MaxValue)]
        public int nbpart { get; set; }

           
        public virtual Jackpot jackpotev { get; set; }
        public virtual Chariot chariotev { get; set; }
        public virtual ICollection<User> userevent { get; set; }

    }
}