
namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class comment
    {
        [Key]
        public long id { get; set; }
        public string content_comment { get; set; }

        [DataType(DataType.Date)]
        public  DateTime date_comment { get; set; }
        [ForeignKey("subject_id")]
        public Nullable<long> subject_id { get; set; }
        [ForeignKey("users_id")]
        public Nullable<long> users_id { get; set; }
    
        public virtual User users { get; set; }
        public virtual subject subject { get; set; }

        public virtual ICollection<likecom> LikeCom { get; set; }
    }
}
