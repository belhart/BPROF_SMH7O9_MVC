using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;

namespace F1Stats.Web.Models
{
    public class CsapatViewModel
    {
        public Csapat EditedCsapat { get; set; }
        public List<Csapat> ListOfCsapatok { get; set; }
    }
}
