using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using F1Stats.Data.Models;
using F1Stats.Repository;

namespace F1Stats.Logic
{
    public class VersenyzoLogic
    {
        public IVersenyzoRepository versenyzoRepo;

        public VersenyzoLogic()
        {
            this.versenyzoRepo = new VersenyzoRepository();
        }

        public VersenyzoLogic(IVersenyzoRepository repo)
        {
            this.versenyzoRepo = repo;
        }

        public IList<Versenyzo> GetAllVersenyzo()
        {
            return this.versenyzoRepo.GetAll().ToList();
        }

        public Versenyzo GetOneVersenyzo(int rajtszam)
        {
            return this.versenyzoRepo.GetOne(rajtszam);
        }

        public bool DeleteVersenyzo(int rajtSzam)
        {
            return this.versenyzoRepo.Deleteversenyzo(rajtSzam);
        }

        public void CreateVersenyzo(Versenyzo versenyzo)
        {
            this.versenyzoRepo.CreateVersenyzo(versenyzo);
        }

        public void CreateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont)
        {
            this.versenyzoRepo.CreateVersenyzo(rajtszam, nev, csapatnev, eletkor, osszpont, idenybelipont);
        }

        public bool UpdateVersenyzo(int rajtszam, string nev, string csapatnev, int eletkor, int osszpont, int idenybelipont)
        {
            return this.versenyzoRepo.UpdateVersenyzoTeljes(rajtszam, nev, csapatnev, eletkor, osszpont, idenybelipont);
        }
    }
}
