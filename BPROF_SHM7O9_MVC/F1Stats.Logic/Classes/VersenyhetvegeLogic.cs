using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using F1Stats.Data.Models;
using F1Stats.Repository;

namespace F1Stats.Logic
{
    public class VersenyhetvegeLogic : IVersenyhetvegeLogic
    {
        public IVersenyhetvegeRepository vhRepo;

        public VersenyhetvegeLogic(string connectionPassword)
        {
            this.vhRepo = new VersenyHetvegeRepository(connectionPassword);
        }

        public VersenyhetvegeLogic(IVersenyhetvegeRepository repo)
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

        public bool UpdateVersenyhetvege(int oldId, Versenyhetvege versenyhetvege)
        {
            return this.vhRepo.UpdateVersenyhetvege(oldId, versenyhetvege);
        }
    }
}
