using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1Stats.Data.Models
{
    public class Versenyzo
    {
        [Key]
        public int rajtszam { get; set; }
        public string nev { get; set; }
        public string csapat_nev { get; set; }
        public int eletkor { get; set; }
        public Nullable<int> ossz_pont { get; set; }
        public Nullable<int> idenybeli_pont { get; set; }
        public virtual Csapat Csapat { get; set; }
        public virtual ICollection<Eredmeny> Eredmeny { get; set; }
    }
}
