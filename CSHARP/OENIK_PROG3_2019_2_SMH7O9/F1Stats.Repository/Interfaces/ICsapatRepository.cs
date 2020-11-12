namespace F1Stats.Repository
{
    using System.Linq;
    using F1Stats.Data;

    public interface ICsapatRepository : IRepository<Csapat, string>
    {
        void CreateCsapat(Csapat csapat);

        new Csapat GetOne(string name);

        new IQueryable<Csapat> GetAll();

        void UpdateMotor(string name, string newMotor);

        void UpdateVersenyekSzama(string name, int verSzam);

        void UpdateGyozelmek(string name, int gyozelmekSzama);

        void DeleteCsapat(string name);
    }
}
