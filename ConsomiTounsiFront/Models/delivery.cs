using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public partial class delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public delivery()
        {
            //this.command = new HashSet<Command>();
        }

        public int id { get; set; }
        public string adresse { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public float frais { get; set; }
        public float poids { get; set; }
        public bool state { get; set; }
        public Nullable<int> deliver_men_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
     //   public virtual ICollection<command> command { get; set; }
        public virtual DeliveryMen deliverMen { get; set; }
        public virtual User user { get; set; }
    }
}

