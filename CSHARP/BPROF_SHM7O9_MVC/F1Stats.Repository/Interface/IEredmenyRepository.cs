using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface IEredmenyRepository
    {
        void CreateEredmeny(Eredmeny eredmeny);

        new Eredmeny GetOne(int eredmenyId);

        new IQueryable<Eredmeny> GetAll();

        void UpdateHelyezes(int eredmenyId, int newHelyezes);

        void UpdatePont(int eredmenyId, int newPont);

        void DeleteEredmeny(int eredmenyId);
    }
}
