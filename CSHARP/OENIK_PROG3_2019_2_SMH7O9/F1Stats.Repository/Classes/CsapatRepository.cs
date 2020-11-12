namespace F1Stats.Repository
{
    using System.Linq;
    using F1Stats.Data;

    public class CsapatRepository : ICsapatRepository
    {
        private F1StatsDatabaseEntities db;

        public CsapatRepository(F1StatsDatabaseEntities db)
        {
            this.db = db;
        }

        public Csapat GetOne(string name)
        {
            return this.db.Csapat.Where(x => x.csapat_nev == name).FirstOrDefault();
        }

        public void UpdateVersenyekSzama(string name, int verSzam)
        {
            var csapat = this.GetOne(name);
            csapat.versenyek_szama = verSzam;
            this.db.SaveChanges();
        }

        public void UpdateMotor(string name, string newMotor)
        {
            var csapat = this.GetOne(name);
            csapat.motor = newMotor;
            this.db.SaveChanges();
        }

        public void CreateCsapat(Csapat csapat)
        {
            this.db.Csapat.Add(csapat);
            this.db.SaveChanges();
        }

        public void DeleteCsapat(string name)
        {
            this.db.Csapat.Remove(this.GetOne(name));
            this.db.SaveChanges();
        }

        public IQueryable<Csapat> GetAll()
        {
            return this.db.Csapat;
        }

        public void UpdateGyozelmek(string name, int gyozelmekSzama)
        {
            var csapat = this.GetOne(name);
            csapat.gyozelmek = gyozelmekSzama;
            this.db.SaveChanges();
        }
    }
}
