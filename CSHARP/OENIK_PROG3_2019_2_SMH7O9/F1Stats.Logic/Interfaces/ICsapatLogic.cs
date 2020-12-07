namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using F1Stats.Data;

    public interface ICsapatLogic
    {
        Csapat GetOneCsapat(string name);

        IList<Csapat> GetAllCsapat();

        void CreateCsapat(Csapat csapat);

        bool DeleteCsapat(string name);

        void CreateCsapat(string name, string motor, int versenyekszama, int gyozelmek);

        void UpdateCsapat(string name, string motor, int versenyekszama, int gyozelmek);
    }
}
