namespace F1Stats.Repository
{
    using System.Linq;
    using F1Stats.Data;

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
    }
}
