using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    public class MyDbContext : DbContext
    {
        public DbSet<City> City { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\байбатыровм\\Documents\\ef_codefirst.mdf;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");
        }
    }
}
