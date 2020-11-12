namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Repository;

    public class VersenyhetvegeLogic : IVersenyhetvegeLogic
    {
        public IVersenyHetvegeRepository vhRepo;

        public VersenyhetvegeLogic()
        {
            this.vhRepo = new VersenyHetvegeRepository(new F1StatsDatabaseEntities());
        }

        public VersenyhetvegeLogic(IVersenyHetvegeRepository repo)
        {
            this.vhRepo = repo;
        }

        public IList<Versenyhetvege> GetAllVersenyhetvege()
        {
            return this.vhRepo.GetAll().ToList();
        }

        public Versenyhetvege GetOneVersenyhetvege(int raceNumber)
        {
            return this.vhRepo.GetOne(raceNumber);
        }

        public void CreateVersenyhetvege(Versenyhetvege versenyhetvege)
        {
            this.vhRepo.CreateVersenyHetvege(versenyhetvege);
        }

        public void DeleteVersenyhetvege(int raceNumber)
        {
            this.vhRepo.DeleteVersenyHetvege(raceNumber);
        }
    }
}
