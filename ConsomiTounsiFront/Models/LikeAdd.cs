using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public class LikeAdd
    {
        [Key]
        public long id { get; set; }
        public bool etat { get; set; }
        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public User user { get; set; }
        [ForeignKey("idAdd")]
        public int idAdd { get; set; }
        public Add add { get; set; }
    }


}