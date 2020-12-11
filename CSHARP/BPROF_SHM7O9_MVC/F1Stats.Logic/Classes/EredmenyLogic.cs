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

        public void DeleteEredmeny(int eredmenyId)
        {
            this.eredmenyRepo.DeleteEredmeny(eredmenyId);
        }

    }
}
