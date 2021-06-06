using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface IVersenyhetvegeRepository : IRepository<Versenyhetvege, int>
    {
        void CreateVersenyHetvege(Versenyhetvege versenyhetvege);

        void CreateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);

        new Versenyhetvege GetOne(int raceNumber);

        new IQueryable<Versenyhetvege> GetAll();

        void UpdateNev(int raceNumber, string newName);

        void UpdateHossz(int raceNumber, int newHossz);

        void UpdateKor(int raceNumber, int newKor);

        void UpdateIdopont(int raceNumber, DateTime newdateTime);

        void UpdateHelyszin(int raceNumber, string newHelyszin);

        bool DeleteVersenyHetvege(int raceNumber);

        bool UpdateVersenyhetvegeTeljes(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);
        bool UpdateVersenyhetvege(int id, Versenyhetvege versenyhetvege);
    }
}
