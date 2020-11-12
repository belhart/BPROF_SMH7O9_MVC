namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using F1Stats.Data;

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
