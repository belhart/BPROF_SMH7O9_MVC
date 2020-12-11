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

        new Eredmeny GetOne(int raceNumber, int rajtSzam);

        new IQueryable<Eredmeny> GetAll();

        void UpdateHelyezes(int raceNumber, int rajtSzam, int newHelyezes);

        void UpdatePont(int raceNumber, int rajtSzam, int newPont);

        void DeleteEredmeny(int raceNumber, int rajtSzam);
    }
}
