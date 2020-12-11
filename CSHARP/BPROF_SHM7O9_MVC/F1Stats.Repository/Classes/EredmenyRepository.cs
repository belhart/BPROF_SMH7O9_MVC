namespace F1Stats.Repository
{
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;

    public class EredmenyRepository : IEredmenyRepository
    {
        private F1StatsDbContext db;

        public EredmenyRepository()
        {
            this.db = new F1StatsDbContext();
        }

        public void CreateEredmeny(Eredmeny eredmeny)
        {
            this.db.Eredmeny.Add(eredmeny);
            this.db.SaveChanges();
        }

        public void DeleteEredmeny(int raceNumber, int rajtSzam)
        {
            this.db.Eredmeny.Remove(this.GetOne(raceNumber, rajtSzam));
            this.db.SaveChanges();
        }

        public IQueryable<Eredmeny> GetAll()
        {
            return this.db.Eredmeny;
        }

        public Eredmeny GetOne(int raceNumber, int rajtSzam)
        {
            return this.db.Eredmeny.Where(x => (x.rajtszam == rajtSzam) && (x.versenyhetvege_szam == raceNumber)).FirstOrDefault();
        }

        public void UpdateHelyezes(int raceNumber, int rajtSzam, int newHelyezes)
        {
            var eredmeny = this.GetOne(raceNumber, rajtSzam);
            eredmeny.helyezes = newHelyezes;
            this.db.SaveChanges();
        }

        public void UpdatePont(int raceNumber, int rajtSzam, int newPont)
        {
            var eredmeny = this.GetOne(raceNumber, rajtSzam);
            eredmeny.pont = newPont;
            this.db.SaveChanges();
        }
    }
}
