namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using F1Stats.Data;

    public interface ICsapatLogic
    {
        Csapat GetOneCsapat(string name);

        IList<Csapat> GetAllCsapat();
    }
}
