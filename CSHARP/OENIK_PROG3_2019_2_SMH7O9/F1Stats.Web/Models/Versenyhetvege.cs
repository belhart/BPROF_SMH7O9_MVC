namespace F1Stats.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Versenyhetvege
    {
        [Display(Name = "Versenyhetvege neve")]
        [Required]
        public string Nev { get; set; }

        [Display(Name = "Versenyhetvege szama")]
        [Required]
        public int Versenyhetvege_szama{ get; set; }

        [Display(Name = "Verseny hossza")]
        [Required]
        public int Hossz { get; set; }

        [Display(Name = "Verseny koreinek szama")]
        [Required]
        public int Kor { get; set; }

        [Display(Name = "Verseny idopontja")]
        [Required]
        public DateTime Idopont { get; set; }

        [Display(Name = "Verseny helyszine")]
        [Required]
        public string Helyszin { get; set; }
    }
}