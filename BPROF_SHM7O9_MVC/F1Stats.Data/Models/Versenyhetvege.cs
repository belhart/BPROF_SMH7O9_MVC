namespace F1Stats.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Versenyhetvege
    {
        public string nev { get; set; }
        [Key]
        public int VERSENYHETVEGE_SZAMA { get; set; }
        public int hossz { get; set; }
        public int kor { get; set; }
        public System.DateTime idopont { get; set; }
        public string helyszin { get; set; }
        public virtual ICollection<Eredmeny> Eredmeny { get; set; }
    }
}
