using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Stats.Web.Models
{
    public class EredmenyViewModel
    {
        public Eredmeny EditedEredmeny { get; set; }
        public List<Eredmeny> ListOfEredmenyek { get; set; }
    }
}
