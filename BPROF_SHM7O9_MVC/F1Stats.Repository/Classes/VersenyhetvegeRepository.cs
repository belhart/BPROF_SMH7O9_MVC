namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;

    public class VersenyHetvegeRepository : IVersenyhetvegeRepository
    {
        private F1StatsDbContext db;

        public VersenyHetvegeRepository(string connectionPassword)
        {
            this.db = new F1StatsDbContext(connectionPassword);
        }

        public void CreateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin)
        {
            Versenyhetvege versenyhetvege = new Versenyhetvege()
            {
                nev = nev,
                VERSENYHETVEGE_SZAMA = versenySzama,
                hossz = hossz,
                kor = kor,
                idopont = idopont,
                helyszin = helyszin,
            };
            this.db.Versenyhetvege.Add(versenyhetvege);
            this.db.SaveChanges();
        }

        public void CreateVersenyHetvege(Versenyhetvege versenyhetvege)
        {
            this.db.Versenyhetvege.Add(versenyhetvege);
            this.db.SaveChanges();
        }

        public bool DeleteVersenyHetvege(int raceNumber)
        {
            try
            {
                this.db.Versenyhetvege.Remove(this.GetOne(raceNumber));
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Versenyhetvege> GetAll()
        {
            return this.db.Versenyhetvege;
        }

        public Versenyhetvege GetOne(int raceNumber)
        {
            return this.db.Versenyhetvege.Where(x => x.VERSENYHETVEGE_SZAMA == raceNumber).FirstOrDefault();
        }

        public void UpdateHelyszin(int raceNumber, string newHelyszin)
        {
            var versenyhetvege = this.GetOne(raceNumber);
            versenyhetvege.helyszin = newHelyszin;
            this.db.SaveChanges();
        }

        public void UpdateHossz(int raceNumber, int newHossz)
        {
            var versenyhetvege = this.GetOne(raceNumber);
            versenyhetvege.hossz = newHossz;
            this.db.SaveChanges();
        }

        public void UpdateIdopont(int raceNumber, DateTime newdateTime)
        {
            var versenyhetvege = this.GetOne(raceNumber);
            versenyhetvege.idopont = newdateTime;
            this.db.SaveChanges();
        }

        public void UpdateKor(int raceNumber, int newKor)
        {
            var versenyhetvege = this.GetOne(raceNumber);
            versenyhetvege.kor = newKor;
            this.db.SaveChanges();
        }

        public void UpdateNev(int raceNumber, string newName)
        {
            var versenyhetvege = this.GetOne(raceNumber);
            versenyhetvege.nev = newName;
            this.db.SaveChanges();
        }

        public bool UpdateVersenyhetvege(int id, Versenyhetvege versenyhetvege)
        {
            try
            {
                Versenyhetvege vhtTemp = this.GetOne(id);
                vhtTemp.helyszin = versenyhetvege.helyszin;
                vhtTemp.nev = versenyhetvege.nev;
                vhtTemp.hossz = versenyhetvege.hossz;
                vhtTemp.kor = versenyhetvege.kor;
                vhtTemp.idopont = versenyhetvege.idopont;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateVersenyhetvegeTeljes(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin)
        {
            try
            {
                Versenyhetvege versenyhetvege = this.GetOne(versenySzama);
                versenyhetvege.nev = nev;
                versenyhetvege.VERSENYHETVEGE_SZAMA = versenySzama;
                versenyhetvege.hossz = hossz;
                versenyhetvege.kor = kor;
                versenyhetvege.idopont = idopont;
                versenyhetvege.helyszin = helyszin;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
