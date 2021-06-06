using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface ICsapatRepository : IRepository<Csapat, string>
    {
        void CreateCsapat(Csapat csapat);

        void CreateCsapat(string name, string motor, int versenyekszama, int gyozelmek);

        new Csapat GetOne(string name);

        new IQueryable<Csapat> GetAll();

        void UpdateMotor(string name, string newMotor);

        void UpdateVersenyekSzama(string name, int verSzam);

        void UpdateGyozelmek(string name, int gyozelmekSzama);

        bool DeleteCsapat(string name);

        bool UpdateCsapatTeljes(string name, string motor, int? versenyekszama, int? gyozelmek);
        bool UpdateCsapat(string name, Csapat csapat);
    }
}
