﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace F1Stats.Data.Models
{
    public class Csapat
    {
        [Key]
        public string csapat_nev { get; set; }
        public string motor { get; set; }
        public Nullable<int> versenyek_szama { get; set; }
        public Nullable<int> gyozelmek { get; set; }
        [JsonIgnore]
        public virtual ICollection<Versenyzo> Versenyzo { get; set; }
    }
}
