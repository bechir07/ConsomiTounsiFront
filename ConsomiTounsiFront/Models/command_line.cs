namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class command_line
    {   [Key]
        public long id { get; set; }
        public int amount { get; set; }
        public float total_product_price { get; set; }
        [ForeignKey("command_reference")]
        public Nullable<long> command_reference { get; set; }
        [ForeignKey("product_id")]
        public Nullable<long> product_id { get; set; }
        public Nullable<long> delivery_id { get; set; }
        public Nullable<long> client_id { get; set; }
        public Nullable<long> chariot_id { get; set; }


        public virtual command command { get; set; }
        public virtual Product product { get; set; }
        //public virtual User client { get; set; }
        //public virtual Delivery delivery { get; set; }
        //public virtual Chariot chariot { get; set; }

    }
}
