using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F1Stats.Web.Models
{
    public class Versenyzo
    {
        [Display(Name = "Versenyzo rajtszama")]
        [Required]
        public int Rajtszam { get; set; }

        [Display(Name = "Versenyzo neve")]
        [Required]
        public string Nev{ get; set; }

        [Display(Name = "Versenyzo csapata")]
        [Required]
        [StringLength(50,MinimumLength = 5)]
        public string CsapatNev { get; set; }

        [Display(Name = "Versenyzo eletkora")]
        [Required]
        public int Eletkor { get; set; }

        [Display(Name = "Versenyzo osszes pontja")]
        [Required]
        public int OsszPont { get; set; }

        [Display(Name = "Versenyzo idenybeli pontja")]
        [Required]
        public int IdenybeliPont { get; set; }
    }
}