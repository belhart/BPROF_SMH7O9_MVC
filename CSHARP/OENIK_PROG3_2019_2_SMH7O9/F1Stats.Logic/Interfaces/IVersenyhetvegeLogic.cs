namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using F1Stats.Data;

    public interface IVersenyhetvegeLogic
    {
        Versenyhetvege GetOneVersenyhetvege(int raceNumber);

        IList<Versenyhetvege> GetAllVersenyhetvege();
    }
}
