namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;

    public class VersenyzoRepository : IVersenyzoRepository
    {
        private F1StatsDbContext db;

        public VersenyzoRepository()
        {
            this.db = new F1StatsDbContext();
        }

        public VersenyzoRepository(F1StatsDbContext db)
        {
            this.db = db;
        }

        public void CreateVersenyzo(Versenyzo versenyzo)
        {
            this.db.Versenyzo.Add(versenyzo);
            this.db.SaveChanges();
        }

        public void CreateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont)
        {
            Versenyzo versenyzo = new Versenyzo()
            {
                rajtszam = rajtszam,
                nev = nev,
                csapat_nev = csapatnev,
                eletkor = eletkor,
                ossz_pont = osszpont,
                idenybeli_pont = idenybelipont,
            };
            this.db.Versenyzo.Add(versenyzo);
            this.db.SaveChanges();
        }

        public bool Deleteversenyzo(int rajtSzam)
        {
            try
            {
                this.db.Versenyzo.Remove(this.GetOne(rajtSzam));
                this.db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<Versenyzo> GetAll()
        {
            return this.db.Versenyzo;
        }

        public Versenyzo GetOne(int rajtSzam)
        {
            return this.db.Versenyzo.Where(x => x.rajtszam == rajtSzam).FirstOrDefault();
        }

        public void UpdateCsapatNev(int rajtSzam, string newCsapatName)
        {
            var versenyzo = this.GetOne(rajtSzam);
            versenyzo.csapat_nev = newCsapatName;
            this.db.SaveChanges();
        }

        public void UpdateEetkor(int rajtSzam, int newEletkor)
        {
            var versenyzo = this.GetOne(rajtSzam);
            versenyzo.eletkor = newEletkor;
            this.db.SaveChanges();
        }

        public void UpdateIdenybeliPont(int rajtSzam, int newIdenybeliPont)
        {
            var versenyzo = this.GetOne(rajtSzam);
            versenyzo.idenybeli_pont = newIdenybeliPont;
            this.db.SaveChanges();
        }

        public void UpdateNev(int rajtSzam, string newName)
        {
            var versenyzo = this.GetOne(rajtSzam);
            versenyzo.nev = newName;
            this.db.SaveChanges();
        }

        public void UpdateOsszPont(int rajtSzam, int newOsszpont)
        {
            var versenyzo = this.GetOne(rajtSzam);
            versenyzo.ossz_pont = newOsszpont;
            this.db.SaveChanges();
        }

        public bool UpdateVersenyzoTeljes(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont)
        {
            try
            {
                var versenyzo = this.GetOne(rajtszam);
                versenyzo.nev = nev;
                versenyzo.csapat_nev = csapatnev;
                versenyzo.eletkor = eletkor;
                versenyzo.ossz_pont = osszpont;
                versenyzo.idenybeli_pont = idenybelipont;
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
