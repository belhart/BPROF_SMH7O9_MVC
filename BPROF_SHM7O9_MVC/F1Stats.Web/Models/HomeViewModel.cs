using F1Stats.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Stats.Web.Models
{
    public class HomeViewModel
    {
        public string TeamWithMostPoints { get; set; }
        public List<ElertPont> ListOfSumPointResult { get; set; }
        public List<string> ListOfEnginePointResult { get; set; }
    }
}
