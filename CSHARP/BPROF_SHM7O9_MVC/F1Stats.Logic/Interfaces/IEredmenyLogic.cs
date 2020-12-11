using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Logic
{
    interface IEredmenyLogic
    {
        Eredmeny GetOneEredmeny(int raceNumber, int rajtSzam);

        IList<Eredmeny> GetAllEredmeny();

    }
}
