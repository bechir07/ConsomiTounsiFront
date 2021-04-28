using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public partial class reparation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reparation()
        {
          //  this.product = new HashSet<product>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> dateReparation { get; set; }
        public float prixReparation { get; set; }
        public string typePanne { get; set; }
        public string state { get; set; }
        public int idProduct { get; set; }
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

       // public virtual Product product { get; set; }
    }
}