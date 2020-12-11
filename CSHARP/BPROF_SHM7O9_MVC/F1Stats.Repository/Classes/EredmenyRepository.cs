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

        public void DeleteEredmeny(int eredmenyId)
        {
            this.db.Eredmeny.Remove(this.GetOne(eredmenyId));
            this.db.SaveChanges();
        }

        public IQueryable<Eredmeny> GetAll()
        {
            return this.db.Eredmeny;
        }

        public Eredmeny GetOne(int eredmenyId)
        {
            return this.db.Eredmeny.Where(x => x.eredmenyId == eredmenyId).FirstOrDefault();
        }

        public void UpdateHelyezes(int eredmenyId, int newHelyezes)
        {
            var eredmeny = this.GetOne(eredmenyId);
            eredmeny.helyezes = newHelyezes;
            this.db.SaveChanges();
        }

        public void UpdatePont(int eredmenyId, int newPont)
        {
            var eredmeny = this.GetOne(eredmenyId);
            eredmeny.pont = newPont;
            this.db.SaveChanges();
        }
    }
}
