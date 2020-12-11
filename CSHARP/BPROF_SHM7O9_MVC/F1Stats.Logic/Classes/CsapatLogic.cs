using System;
using System.Collections.Generic;
using System.Text;
using F1Stats.Repository;
using F1Stats.Data.Models;
using System.Linq;

namespace F1Stats.Logic
{
    public class CsapatLogic : ICsapatLogic
    {
        public ICsapatRepository csapatRepo;

        public CsapatLogic()
        {
            this.csapatRepo = new CsapatRepository();
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

        public bool DeleteCsapat(string name)
        {
            return this.csapatRepo.DeleteCsapat(name);
        }

        public void CreateCsapat(string name, string motor, int versenyekszama, int gyozelmek)
        {
            this.csapatRepo.CreateCsapat(name, motor, versenyekszama, gyozelmek);
        }

        public bool UpdateCsapat(string name, string motor, int versenyekszama, int gyozelmek)
        {
            return this.csapatRepo.UpdateCsapatTeljes(name, motor, versenyekszama, gyozelmek);
        }

    }
}
