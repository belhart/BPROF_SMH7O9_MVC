namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;

    public interface IVersenyHetvegeRepository : IRepository<Versenyhetvege, int>
    {
        void CreateVersenyHetvege(Versenyhetvege versenyhetvege);

        new Versenyhetvege GetOne(int raceNumber); //VHSzam = VersenyHetvegeSzam (átírni VersenyHetvegeIndex ?)

        new IQueryable<Versenyhetvege> GetAll();

        void UpdateNev(int raceNumber, string newName);

        void UpdateHossz(int raceNumber, int newHossz);

        void UpdateKor(int raceNumber, int newKor);

        void UpdateIdopont(int raceNumber, DateTime newdateTime);

        void UpdateHelyszin(int raceNumber, string newHelyszin);

        void DeleteVersenyHetvege(int raceNumber);
    }
}
