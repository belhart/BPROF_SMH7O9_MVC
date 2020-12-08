namespace F1Stats.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Repository;

    public class VersenyhetvegeLogic : IVersenyhetvegeLogic
    {
        public IVersenyHetvegeRepository vhRepo;

        public VersenyhetvegeLogic()
        {
            this.vhRepo = new VersenyHetvegeRepository(new F1StatsDatabaseEntities());
        }

        public VersenyhetvegeLogic(IVersenyHetvegeRepository repo)
        {
            this.vhRepo = repo;
        }

        public IList<Versenyhetvege> GetAllVersenyhetvege()
        {
            return this.vhRepo.GetAll().ToList();
        }

        public Versenyhetvege GetOneVersenyhetvege(int versenySzama)
        {
            return this.vhRepo.GetOne(versenySzama);
        }

        public void CreateVersenyhetvege(Versenyhetvege versenyhetvege)
        {
            this.vhRepo.CreateVersenyHetvege(versenyhetvege);
        }

        public bool DeleteVersenyhetvege(int versenySzama)
        {
            return this.vhRepo.DeleteVersenyHetvege(versenySzama);
        }

        public void CreateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin)
        {
            this.vhRepo.CreateVersenyhetvege(nev, versenySzama, hossz, kor, idopont, helyszin);
        }

        public bool UpdateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin)
        {
            return this.vhRepo.UpdateVersenyhetvegeTeljes(nev, versenySzama, hossz, kor, idopont, helyszin);
        }
    }
}
