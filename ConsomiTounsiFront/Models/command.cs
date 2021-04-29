
namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class command
    {
    
        [Key]
        public long reference { get; set; }
        public float total_price { get; set; }
        public string type { get; set; }

        [DataType(DataType.Date)]
        public DateTime order_date { get; set; }


        [ForeignKey("delivery_id")]
        public Nullable<long> delivery_id { get; set; }
        // public Nullable<int> donation_id { get; set; }
        [ForeignKey("client_id")]
        public Nullable<long> client_id { get; set; }
        //public string type { get; set; }
        [ForeignKey("chariot_id")]
        public Nullable<long> chariot_id { get; set; }

       // public Nullable<int> bill_bill_id { get; set; }
       // public virtual bill bill { get; set; }
        public virtual bill @bill { get; set; }
        public virtual Chariot chariot { get; set; }
   
        public virtual ICollection<command_line> command_line { get; set; }
        public virtual User client { get; set; }
        public virtual Delivery delivery { get; set; }

       // public virtual payment payment { get; set; }
        // public virtual Donation donation { get; set; }
    }
}
