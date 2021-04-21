using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class User
    {

        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Username Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string username { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string ConfirmPassword { get; set; }

        private string Password;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string password
        {
            get { return Password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20) Password = value;
                else Console.WriteLine("Le password doit avoir une taille dans l'intervalle [5, 20]");
            }
        }

        public bool IsApproved { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        // foreign Key properties
        public virtual ICollection<Role> roles { get; set; }
        public virtual ICollection<Donation> donations { get; set; }
        public virtual ICollection<Event> eventsuser { get; set; }
    }
}