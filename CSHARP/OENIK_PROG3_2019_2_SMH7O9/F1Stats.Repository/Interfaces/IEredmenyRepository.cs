namespace F1Stats.Repository
{
    using System.Linq;
    using F1Stats.Data;

    public interface IEredmenyRepository : IRepository<Eredmeny, int, int>
    {
        void CreateEredmeny(Eredmeny eredmeny);

        new Eredmeny GetOne(int raceNumber, int rajtSzam);

        new IQueryable<Eredmeny> GetAll();

        void UpdateHelyezes(int raceNumber, int rajtSzam, int newHelyezes);

        void UpdatePont(int raceNumber, int rajtSzam, int newPont);

        void DeleteEredmeny(int raceNumber, int rajtSzam);
    }
}
