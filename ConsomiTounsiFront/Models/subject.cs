using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public partial class subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subject()
        {
           // this.comment = new HashSet<comment>();
        }

        public int id { get; set; }
        public string category { get; set; }
        public Nullable<System.DateTime> dateSubject { get; set; }
        public string description { get; set; }
        public string subjectName { get; set; }
        public float evaluate { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<comment> comment { get; set; }
    }
}