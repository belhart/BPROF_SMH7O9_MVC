using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Stats.Web.Models
{
    public class VersenyhetvegeViewModel
    {
        public Versenyhetvege EditedVersenyhetvege { get; set; }
        public List<Versenyhetvege> ListOfVersenyhetvegek { get; set; }
    }
}
