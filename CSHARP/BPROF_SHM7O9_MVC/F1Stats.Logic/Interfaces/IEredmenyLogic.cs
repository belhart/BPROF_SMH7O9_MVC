using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Logic
{
    public interface IEredmenyLogic
    {
        Eredmeny GetOneEredmeny(int eredmenyId);

        IList<Eredmeny> GetAllEredmeny();

    }
}
