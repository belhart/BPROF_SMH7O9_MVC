using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Data.Models
{
    public class Eredmeny
    {
        public int versenyhetvege_szam { get; set; }
        public int rajtszam { get; set; }
        public Nullable<int> helyezes { get; set; }
        public Nullable<int> pont { get; set; }
        public virtual Versenyhetvege Versenyhetvege { get; set; }
        public virtual Versenyzo Versenyzo { get; set; }
    }
}
