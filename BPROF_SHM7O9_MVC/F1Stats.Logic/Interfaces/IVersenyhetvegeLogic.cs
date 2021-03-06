﻿using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Logic
{
    public interface IVersenyhetvegeLogic
    {
        Versenyhetvege GetOneVersenyhetvege(int versenySzama);

        IList<Versenyhetvege> GetAllVersenyhetvege();

        void CreateVersenyhetvege(Versenyhetvege versenyhetvege);

        bool DeleteVersenyhetvege(int versenySzama);

        void CreateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);

        bool UpdateVersenyhetvege(string nev, int versenySzama, int hossz, int kor, DateTime idopont, string helyszin);
        bool UpdateVersenyhetvege(int oldId, Versenyhetvege versenyhetvege);
    }
}
