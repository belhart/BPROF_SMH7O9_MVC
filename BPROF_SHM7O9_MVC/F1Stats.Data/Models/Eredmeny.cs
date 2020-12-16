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
        public int helyezes { get; set; }
        public int pont { get; set; }
        public virtual Versenyhetvege Versenyhetvege { get; set; }
        public virtual Versenyzo Versenyzo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Eredmeny)
            {
                Eredmeny other = obj as Eredmeny;
                return this.eredmenyId == other.eredmenyId &&
                    this.versenyhetvege_szam == other.versenyhetvege_szam &&
                    this.rajtszam == other.rajtszam &&
                    this.helyezes == other.helyezes &&
                    this.pont == other.pont;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return eredmenyId;
        }
    }
}
