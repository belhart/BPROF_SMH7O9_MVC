﻿//------------------------------------------------------------------------------
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

    public partial class Csapat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Csapat()
        {
            this.Versenyzo = new HashSet<Versenyzo>();
        }

        public string csapat_nev { get; set; }
        public string motor { get; set; }
        public Nullable<int> versenyek_szama { get; set; }
        public Nullable<int> gyozelmek { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Versenyzo> Versenyzo { get; set; }
    }
}
