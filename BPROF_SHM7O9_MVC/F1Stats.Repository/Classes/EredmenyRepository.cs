﻿namespace F1Stats.Repository
{
    using System;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;

    public class EredmenyRepository : IEredmenyRepository
    {
        private F1StatsDbContext db;

        public EredmenyRepository(string connectionPassword)
        {
            this.db = new F1StatsDbContext(connectionPassword);
        }

        public EredmenyRepository(F1StatsDbContext db)
        {
            this.db = db;
        }

        public void CreateEredmeny(Eredmeny eredmeny)
        {
            this.db.Eredmeny.Add(eredmeny);
            this.db.SaveChanges();
        }

        public bool DeleteEredmeny(int eredmenyId)
        {
            try
            {
                this.db.Eredmeny.Remove(this.GetOne(eredmenyId));
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Eredmeny> GetAll()
        {
            return this.db.Eredmeny;
        }

        public Eredmeny GetOne(int eredmenyId)
        {
            return this.db.Eredmeny.Where(x => x.eredmenyId == eredmenyId).FirstOrDefault();
        }

        public void UpdateHelyezes(int eredmenyId, int newHelyezes)
        {
            var eredmeny = this.GetOne(eredmenyId);
            eredmeny.helyezes = newHelyezes;
            this.db.SaveChanges();
        }

        public void UpdatePont(int eredmenyId, int newPont)
        {
            var eredmeny = this.GetOne(eredmenyId);
            eredmeny.pont = newPont;
            this.db.SaveChanges();
        }

        public bool UpdateEredmenyTeljes(int id, int versenyhetvege_szam, int rajtszam, int helyezes, int pont)
        {
            try
            {
                var eredmeny = this.GetOne(id);
                eredmeny.versenyhetvege_szam = versenyhetvege_szam;
                eredmeny.rajtszam = rajtszam;
                eredmeny.helyezes = helyezes;
                eredmeny.pont = pont;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEredmeny(int id, Eredmeny eredmeny)
        {
            try
            {
                var eredmenytTemp = this.GetOne(id);
                eredmenytTemp.versenyhetvege_szam = eredmeny.versenyhetvege_szam;
                eredmenytTemp.rajtszam = eredmeny.rajtszam;
                eredmenytTemp.helyezes = eredmeny.helyezes;
                eredmenytTemp.pont = eredmeny.pont;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
