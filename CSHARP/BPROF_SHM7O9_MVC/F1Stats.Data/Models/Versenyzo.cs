using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace F1Stats.Data.Models
{
    public class Versenyzo
    {
        [Key]
        [NotNull]
        public int rajtszam { get; set; }
        public string nev { get; set; }
        [ForeignKey("Csapat")]
        public string csapat_nev { get; set; }
        [NotNull]
        public int eletkor { get; set; }
        [NotNull]
        public int ossz_pont { get; set; }
        [NotNull]
        public int idenybeli_pont { get; set; }
        public virtual Csapat Csapat { get; set; }
        public virtual ICollection<Eredmeny> Eredmeny { get; set; }
    }
}
