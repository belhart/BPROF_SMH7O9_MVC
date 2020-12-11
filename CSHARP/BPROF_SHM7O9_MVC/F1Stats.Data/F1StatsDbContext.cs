using F1Stats.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Data
{
    public class F1StatsDbContext : DbContext
    {
        public F1StatsDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\F1StatsDatabase.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        public virtual DbSet<Csapat> Csapat { get; set; }
        public virtual DbSet<Eredmeny> Eredmeny { get; set; }
        public virtual DbSet<Versenyzo> Versenyzo { get; set; }
        public virtual DbSet<Versenyhetvege> Versenyhetvege { get; set; }
    }
}
