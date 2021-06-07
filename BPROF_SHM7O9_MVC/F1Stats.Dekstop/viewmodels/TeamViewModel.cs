using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Stats.Dekstop.viewmodels
{
    public class TeamViewModel
    {
        private string _token;
        public string TOKEN
        {
            get { return _token; }
            set { _token = value; }
        }
        public TeamViewModel(string token)
        {
            this.TOKEN = token;
        }
    }
}
