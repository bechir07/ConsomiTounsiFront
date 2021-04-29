using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class DeliveryMen
    {
        public DeliveryMen()
        {
            this.delivery = new HashSet<delivery>();
        }

        public bool available { get; set; }
        public float prime { get; set; }
        public int id { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string actived { get; set; }
        [NotMapped]
        [JsonIgnore]
        public String lat { get; set; }
        [NotMapped]
        [JsonIgnore]
        public String lon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<delivery> delivery { get; set; }
        public virtual User user { get; set; }
    }
}
