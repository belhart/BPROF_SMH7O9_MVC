using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface IVersenyzoRepository : IRepository<Versenyzo, int>
    {
        void CreateVersenyzo(Versenyzo versenyzo);

        void CreateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont);

        new Versenyzo GetOne(int rajtSzam);

        new IQueryable<Versenyzo> GetAll();

        void UpdateNev(int rajtSzam, string newName);

        void UpdateCsapatNev(int rajtSzam, string newCsapatName);

        void UpdateEetkor(int rajtSzam, int newEletkor);

        void UpdateOsszPont(int rajtSzam, int newOsszpont);

        void UpdateIdenybeliPont(int rajtSzam, int newIdenybeliPont);

        bool Deleteversenyzo(int rajtSzam);

        bool UpdateVersenyzoTeljes(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont);
        bool UpdateVersenyzo(int id, Versenyzo versenyzo);
    }
}
