//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace F1Stats.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Eredmeny
    {
        public int versenyhetvege_szam { get; set; }
        public int rajtszam { get; set; }
        public Nullable<int> helyezes { get; set; }
        public Nullable<int> pont { get; set; }
    
        public virtual Versenyhetvege Versenyhetvege { get; set; }
        public virtual Versenyzo Versenyzo { get; set; }
    }
}
