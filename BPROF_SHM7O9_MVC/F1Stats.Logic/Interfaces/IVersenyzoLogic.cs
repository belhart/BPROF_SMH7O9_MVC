using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Logic
{
    public interface IVersenyzoLogic
    {
        Versenyzo GetOneVersenyzo(int rajtszam);

        IList<Versenyzo> GetAllVersenyzo();

        void CreateVersenyzo(Versenyzo versenyzo);

        bool DeleteVersenyzo(int rajtSzam);

        void CreateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont);

        bool UpdateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont);

    }
}
