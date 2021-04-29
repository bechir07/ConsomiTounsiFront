using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{

    public partial class reclamation
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dateLimit { get; set; }
        public string decision { get; set; }
        public string objet { get; set; }
        public bool state { get; set; }
        public string typeReclamation { get; set; }
        public Nullable<int> users_id { get; set; }

        public virtual User user { get; set; }
    }
}