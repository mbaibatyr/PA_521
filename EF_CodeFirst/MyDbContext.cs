using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    public class MyDbContext : DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\байбатыровм\\Documents\\ef_codefirst.mdf;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>().HasData(
        //         new City
        //         {
        //             Id = 1,
        //             Name = "Almaty",
        //             Capital = "Astana",
        //             Year = null,
        //             Population = null,
        //             Location = "88888"
        //         },
        //          new City
        //          {
        //              Id = 2,
        //              Name = "New York",
        //              Capital = "Washington",
        //              Year = null,
        //              Population = null,
        //              Location = "666"
        //          }
        //    );
        //}
    }
}
