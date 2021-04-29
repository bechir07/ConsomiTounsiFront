
namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class bill
    {
      
        [Key]
        public long bill_id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_of_bill { get; set; }

        public string payment_type { get; set; }
        public string state { get; set; }
        public float total_price { get; set; }
        [ForeignKey("command_reference")]
        public long? command_reference { get; set; }
        //[ForeignKey("payment_id")]
       // public Nullable<long> payment_id { get; set; }
        public virtual ICollection<payment> payment { get; set; }
        public virtual command command { get; set; }
    }
}
