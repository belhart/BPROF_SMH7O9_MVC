namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Repository;

    public class CsapatLogic : ICsapatLogic
    {
        public ICsapatRepository csapatRepo;

        public CsapatLogic()
        {
            this.csapatRepo = new CsapatRepository(new F1StatsDatabaseEntities());
        }

        public CsapatLogic(ICsapatRepository repo)
        {
            this.csapatRepo = repo;
        }

        public IList<Csapat> GetAllCsapat()
        {
            return this.csapatRepo.GetAll().ToList();
        }

        public Csapat GetOneCsapat(string name)
        {
            return this.csapatRepo.GetOne(name);
        }

        public void CreateCsapat(Csapat csapat)
        {
            this.csapatRepo.CreateCsapat(csapat);
        }

        public void DeleteCsapat(string name)
        {
            this.csapatRepo.DeleteCsapat(name);
        }

        public void UpdateMotor(string name, string newMotor)
        {
            this.csapatRepo.UpdateMotor(name, newMotor);
        }

        public void UpdateVersenySzam(string name, int newRaceNumber)
        {
            this.csapatRepo.UpdateVersenyekSzama(name, newRaceNumber);
        }

        public void UpdateGyozelmek(string name, int newGyozelmekSzama)
        {
            this.csapatRepo.UpdateGyozelmek(name, newGyozelmekSzama);
        }
    }
}
