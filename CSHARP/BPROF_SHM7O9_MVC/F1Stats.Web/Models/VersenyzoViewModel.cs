using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;

namespace F1Stats.Web.Models
{
    public class VersenyzoViewModel
    {
        public Versenyzo EditedVersenyzo { get; set; }
        public List<Versenyzo> ListOfVersenyzok { get; set; }
    }
}
