namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using F1Stats.Data;

    public interface IEredmenyLogic
    {
        Eredmeny GetOneEredmeny(int raceNumber, int rajtSzam);

        IList<Eredmeny> GetAllEredmeny();
    }
}
