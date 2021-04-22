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
        public long Id { get; set; }
        public bool Etat { get; set; }
        /*[ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }*/
        [ForeignKey("IdAdd")]
        public int IdAdd { get; set; }
        public Add Add { get; set; }
    }
}