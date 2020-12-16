using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface IEredmenyRepository : IRepository<Eredmeny, int>
    {
        void CreateEredmeny(Eredmeny eredmeny);

        new Eredmeny GetOne(int eredmenyId);

        new IQueryable<Eredmeny> GetAll();

        void UpdateHelyezes(int eredmenyId, int newHelyezes);

        void UpdatePont(int eredmenyId, int newPont);

        bool DeleteEredmeny(int eredmenyId);

        bool UpdateEredmenyTeljes(int id, int versenyhetvege_szam, int rajtszam, int helyezes, int pont);
    }
}
