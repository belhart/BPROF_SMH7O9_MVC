namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;

    public class VersenyHetvegeRepository : IVersenyHetvegeRepository
    {
        private F1StatsDatabaseEntities db;

        public VersenyHetvegeRepository(F1StatsDatabaseEntities db)
        {
            this.db = db;
        }

        public void CreateVersenyHetvege(Versenyhetvege versenyhetvege)
        {
            this.db.Versenyhetvege.Add(versenyhetvege);
            this.db.SaveChanges();
        }

        public void DeleteVersenyHetvege(int raceNumber)
        {
            this.db.Versenyhetvege.Remove(this.GetOne(raceNumber));
            this.db.SaveChanges();
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

        IQueryable<Versenyhetvege> IRepository<Versenyhetvege, int>.GetAll()
        {
            return this.db.Versenyhetvege;
        }
    }
}
