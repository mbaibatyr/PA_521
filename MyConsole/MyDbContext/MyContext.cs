using Microsoft.EntityFrameworkCore;
using MyConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole.MyDbContext
{
    public class MyContext : DbContext
    {
        //public MyContext(DbContextOptions<MyContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\байбатыровм\\Documents\\mydb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True");
        }

        public DbSet<City> City { get; set; }
    }
}
