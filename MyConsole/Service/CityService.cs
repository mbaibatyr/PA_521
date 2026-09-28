using MyConsole.Abstract;
using MyConsole.Model;
using MyConsole.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole.Service
{
    public class CityService : ICity
    {
        public IEnumerable<City> CityGetAll()
        {
            using var db = new MyContext();
            return db.City.ToList();
        }
    }
}
