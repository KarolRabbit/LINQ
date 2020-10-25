using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Filtrowanie_sortowanie_wyswietlanie;

namespace _5_Laczenie_grupowanie_agregowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ReadFiles("paliwo.csv");
            var manufacturers = ReadManufacturers("producent.csv");

            var question = from car in cars
                           join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                           orderby car.BurningInGeneral descending
                           select new
                           {
                               manufacturer.Headquarters,
                               car.BurningInGeneral,
                               car.Model,
                               car.Manufacturer
                           };

            foreach (var item in question.Take(15))
            {
                Console.WriteLine("{0,-15} {1,-55} {2,-10}", item.Headquarters, $"{item.Manufacturer} {item.Model}",  item.BurningInGeneral);
                Console.WriteLine("----------------------------------------------------------------");
            }

            Console.ReadKey();
        }

        private static List<Manufacturer> ReadManufacturers(string path)
        {
            var question = File.ReadAllLines(path).Where(l => l.Length > 1)
                                                  .Select(l =>
                                                 {
                                                     var manufacturerProperties = l.Split(',');
                                                     return new Manufacturer
                                                     {
                                                         Name = manufacturerProperties[0],
                                                         Headquarters = manufacturerProperties[1],
                                                         Year = int.Parse(manufacturerProperties[2])
                                                     };
                                                 });
            return question.ToList();
        }

        private static List<Car> ReadFilesQuestion(string path)
        {
            var question = from line in File.ReadAllLines(path).Skip(1)
                           where line.Length > 1
                           select Car.TransformCSV(line);
            return question.ToList();

        }

        private static List<Car> ReadFiles(string path)
        {
            return File.ReadAllLines(path).Where(l => l.Length > 1)
                                          .Skip(1)
                                          .TakeLineReturnCar().ToList();

        }
    }
}
