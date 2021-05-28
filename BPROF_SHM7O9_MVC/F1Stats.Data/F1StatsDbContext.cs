using F1Stats.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Data
{
    public class F1StatsDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly string connectionPassword;

        public F1StatsDbContext(string connectionPassword)
        {
            this.connectionPassword = connectionPassword;
            this.Database.EnsureCreated();
        }

        public F1StatsDbContext()
        {
            this.Database.EnsureCreated();
        }

        public F1StatsDbContext(DbContextOptions<F1StatsDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\F1StatsDatabase.mdf;integrated security=True;MultipleActiveResultSets=True");
                */
                var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka_teszt;user=projektmunka");
                builder.Password = this.connectionPassword;
                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "27b787da-9626-4302-9dfc-a66a75a440db", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "d2b948cc-8ba9-4ad4-b1b0-958432e22d2e", Name = "User", NormalizedName = "USER" }
            );
        }

        public virtual DbSet<Csapat> Csapat { get; set; }
        public virtual DbSet<Eredmeny> Eredmeny { get; set; }
        public virtual DbSet<Versenyzo> Versenyzo { get; set; }
        public virtual DbSet<Versenyhetvege> Versenyhetvege { get; set; }
    }
}
