namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Repository;

    public class EredmenyLogic : IEredmenyLogic
    {
        public IEredmenyRepository eredmenyRepo;

        public EredmenyLogic()
        {
            F1StatsDatabaseEntities db = new F1StatsDatabaseEntities();
            this.eredmenyRepo = new EredmenyRepository(new F1StatsDatabaseEntities());
        }

        public EredmenyLogic(IEredmenyRepository repo)
        {
            this.eredmenyRepo = repo;
        }

        public IList<Eredmeny> GetAllEredmeny()
        {
            return this.eredmenyRepo.GetAll().ToList();
        }

        public Eredmeny GetOneEredmeny(int raceNumber, int rajtSzam)
        {
            return this.eredmenyRepo.GetOne(raceNumber, rajtSzam);
        }

        public void CreateEredmeny(Eredmeny eredmeny)
        {
            this.eredmenyRepo.CreateEredmeny(eredmeny);
        }

        public void DeleteEredmeny(int raceNumber, int rajtSzam)
        {
            this.eredmenyRepo.DeleteEredmeny(raceNumber, rajtSzam);
        }
    }
}
