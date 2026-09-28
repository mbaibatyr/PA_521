using MyConsole.Model;
using MyConsole.MyDbContext;
using MyConsole.Service;
using System;
using System.Data;

namespace MyConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityService cityService = new CityService();
            //var data = cityService.CityGetAll();
            //foreach (City item in data)
            //{
            //    Console.WriteLine($"{item.id} - {item.name} - {item.population}");
            //}

            //var item = cityService.CityGetById(1);
            //if(item != null)
            //    Console.WriteLine($"{item.id} - {item.name} - {item.population}");
            //else
            //    Console.WriteLine($"данные не найдены");

            var item2 = cityService.CityIns(new City { name = "Шымкент", population = 1500000, year = 1990});
            Console.WriteLine(item2);

            var data = cityService.CityGetAll();
            foreach (City item in data)
            {
                Console.WriteLine($"{item.id} - {item.name} - {item.population}");
            }

            //var dt = MyTable.GetDataTable();
            //foreach (DataRow item in dt.Rows)
            //{
            //    Console.WriteLine($"{item[0]} - {item["name2"]}");
            //}

            //var list = MyTable.GetList();
            //foreach (var item in list.Where(z=>z.id > 1))
            //{
            //    Console.WriteLine($"{item.id} - {item.name}");
            //}


        }
    }
}
