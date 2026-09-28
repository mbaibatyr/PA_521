using MyConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole.Abstract
{
    public interface ICity
    {
        IEnumerable<City> CityGetAll();
        City CityGetById(int id);
        string CityIns(City city);
    }
}
