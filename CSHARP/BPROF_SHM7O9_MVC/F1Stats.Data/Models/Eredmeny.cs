using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace F1Stats.Data.Models
{
    public class Eredmeny
    {
        [Key]
        public int eredmenyId { get; set; }
        [ForeignKey("Versenyhetvege")]
        public int versenyhetvege_szam { get; set; }
        [ForeignKey("Versenyzo")]
        public int rajtszam { get; set; }
        public Nullable<int> helyezes { get; set; }
        public Nullable<int> pont { get; set; }
        public virtual Versenyhetvege Versenyhetvege { get; set; }
        public virtual Versenyzo Versenyzo { get; set; }
    }
}
