using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Filtrowanie_sortowanie_wyswietlanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ReadFiles("paliwo.csv");

            var question = cars.OrderByDescending(c => c.BurningInGeneral).ThenBy(c => c.Manufacturer).ThenBy(c=>c.Model).Take(15);
            var question2 = from car in cars
                            orderby car.BurningInGeneral descending, car.Manufacturer, car.Model
                            select car;
   
            foreach (var car in question2.Take(10))
            {
                Console.WriteLine("{0,-55} {1,-10}", $"{car.Manufacturer} {car.Model}", car.BurningInGeneral);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.ReadKey();    
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
                                          .Select(Car.TransformCSV).ToList();
                                            
        }
    }
}
