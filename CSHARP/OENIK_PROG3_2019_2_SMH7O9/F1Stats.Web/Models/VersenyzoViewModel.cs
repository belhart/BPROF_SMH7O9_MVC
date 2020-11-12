using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1Stats.Web.Models
{
    public class VersenyzoViewModel
    {
        public Versenyzo EditedVersenyzo { get; set; }
        public List<Versenyzo> ListOfVersenyzok { get; set; }
    }
}