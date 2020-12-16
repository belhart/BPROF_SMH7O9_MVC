using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using F1Stats.Data.Models;
using F1Stats.Repository;

namespace F1Stats.Logic
{
    public class EredmenyLogic : IEredmenyLogic
    {
        public IEredmenyRepository eredmenyRepo;

        public EredmenyLogic()
        {
            this.eredmenyRepo = new EredmenyRepository();
        }

        public EredmenyLogic(IEredmenyRepository repo)
        {
            this.eredmenyRepo = repo;
        }

        public IList<Eredmeny> GetAllEredmeny()
        {
            return this.eredmenyRepo.GetAll().ToList();
        }

        public Eredmeny GetOneEredmeny(int eredmenyId)
        {
            return this.eredmenyRepo.GetOne(eredmenyId);
        }

        public void CreateEredmeny(Eredmeny eredmeny)
        {
            this.eredmenyRepo.CreateEredmeny(eredmeny);
        }

        public bool DeleteEredmeny(int eredmenyId)
        {
            return this.eredmenyRepo.DeleteEredmeny(eredmenyId);
        }

        public void CreateEredmeny(int id, int versenyhetvege_szam, int helyezes, int pont)
        {
            
        }

        public bool UpdateEredmeny(int id, int versenyhetvege_szam, int rajtszam, int helyezes, int pont)
        {
            return this.eredmenyRepo.UpdateEredmenyTeljes(id, versenyhetvege_szam, rajtszam, helyezes,pont);
        }
    }
}
