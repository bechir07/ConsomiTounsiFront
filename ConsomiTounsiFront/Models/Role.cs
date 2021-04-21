using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class Role
    {
        [Key]
        public long id { get; set; }

        private string RoleName;
        [Required(ErrorMessage = "RoleName is required")]
        [MinLength(12)]
        public string roleName
        {
            get { return RoleName; }
            set
            {
                RoleName= value.ToUpper();
            }
        }

        // foreign Key properties
        public virtual ICollection<User> users { get; set; }
    }
}