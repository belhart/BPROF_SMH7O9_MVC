using System.ComponentModel.DataAnnotations;

namespace F1Stats.Web.Models
{
    public class Csapat
    {
        [Display(Name = "Csapat neve")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string CsapatNev { get; set; }

        [Display(Name = "Csapat motor szallitoja")]
        [Required]
        public string Motor { get; set; }

        [Display(Name = "Csapat versenyeinek szama")]
        [Required]
        public int VersenyekSzama { get; set; }

        [Display(Name = "Csapat osszes gyozelme")]
        [Required]
        public int Gyozelmek { get; set; }
    }
}