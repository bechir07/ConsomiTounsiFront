using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public partial class exchange
    {
        public int numCoupon { get; set; }
        public float couponValue { get; set; }
        public Nullable<System.DateTime> dateLimite { get; set; }
        public Nullable<int> users_id { get; set; }
        public string state { get; set; }

        public virtual User users { get; set; }
    }
}