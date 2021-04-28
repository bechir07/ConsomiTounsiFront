using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class likecom
    {
        [Key]
        public long id { get; set; }
        [ForeignKey("comment_id")]
        public Nullable<int> comment_id { get; set; }
        [ForeignKey("users_id")]
        public Nullable<int> users_id { get; set; }

        public virtual User user { get; set; }
        public virtual comment comment { get; set; }
    }
}