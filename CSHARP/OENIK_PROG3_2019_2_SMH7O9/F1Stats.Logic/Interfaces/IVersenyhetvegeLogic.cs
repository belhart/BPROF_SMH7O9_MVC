namespace F1Stats.Logic
{
    using System;
    using System.Collections.Generic;
    using F1Stats.Data;

    public interface IVersenyhetvegeLogic
    {
        Versenyhetvege GetOneVersenyhetvege(int versenySzama);

        IList<Versenyhetvege> GetAllVersenyhetvege();

        void CreateVersenyhetvege(Versenyhetvege versenyhetvege);

        bool DeleteVersenyhetvege(int versenySzama);

        void CreateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);

        bool UpdateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);
    }
}
