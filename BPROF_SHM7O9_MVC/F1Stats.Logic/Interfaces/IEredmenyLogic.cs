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
        void CreateEredmeny(Eredmeny eredmeny);

        bool DeleteEredmeny(int id);

        void CreateEredmeny(int id, int versenyhetvege_szam, int helyezes, int pont);

        bool UpdateEredmeny(int id, int versenyhetvege_szam, int rajtszam, int helyezes, int pont);


    }
}
