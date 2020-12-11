using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Logic.Interfaces
{
    interface ICsapatLogic
    {
        Csapat GetOneCsapat(string name);

        IList<Csapat> GetAllCsapat();

        void CreateCsapat(Csapat csapat);

        bool DeleteCsapat(string name);

        void CreateCsapat(string name, string motor, int versenyekszama, int gyozelmek);

        bool UpdateCsapat(string name, string motor, int versenyekszama, int gyozelmek);

    }
}
