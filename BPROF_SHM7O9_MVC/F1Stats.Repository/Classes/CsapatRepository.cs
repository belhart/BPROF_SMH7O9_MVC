namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;

    public class CsapatRepository : ICsapatRepository
    {
        private F1StatsDbContext db;

        public CsapatRepository(string connectionPassword)
        {
            this.db = new F1StatsDbContext(connectionPassword);
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

        public bool DeleteCsapat(string name)
        {
            try
            {
                this.db.Csapat.Remove(this.GetOne(name));
                this.db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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

        public void CreateCsapat(string name, string motor, int versenyekszama, int gyozelmek)
        {
            Csapat csapat = new Csapat()
            {
                csapat_nev = name,
                motor = motor,
                versenyek_szama = versenyekszama,
                gyozelmek = gyozelmek,
            };
            this.db.Csapat.Add(csapat);
            this.db.SaveChanges();
        }

        public bool UpdateCsapatTeljes(string name, string motor, int? versenyekszama, int? gyozelmek)
        {
            try
            {
                var csapat = this.GetOne(name);
                csapat.csapat_nev = name;
                csapat.motor = motor;
                csapat.versenyek_szama = versenyekszama;
                csapat.gyozelmek = gyozelmek;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
