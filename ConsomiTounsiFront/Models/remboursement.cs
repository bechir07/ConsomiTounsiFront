using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public partial class remboursement
    {
        public long id { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string receipt_email { get; set; }
        public string stripeToken { get; set; }
    }
}