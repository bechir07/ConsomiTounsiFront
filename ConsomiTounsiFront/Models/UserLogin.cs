using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        public string username { get; set; }

        private string Password;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        //[MinLength(8)]
        public string password
        {
            get { return Password; }
            set
            {
                if (value.Length >= 0 && value.Length <= 20) Password = value;
                else Console.WriteLine("Le password doit avoir une taille dans l'intervalle [5, 20]");
            }
        }
    }
}