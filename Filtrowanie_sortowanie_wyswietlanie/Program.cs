using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Filtrowanie_sortowanie_wyswietlanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ReadFiles("paliwo.csv");

            var question = cars.OrderByDescending(c => c.BurningInGeneral)
                               .ThenBy(c => c.Manufacturer)
                               .ThenBy(c => c.Model)
                               .Take(15)
                               .Select(c => new { c.Manufacturer, c.Model, c.BurningInGeneral });

            var question2 = from car in cars
                            orderby car.BurningInGeneral descending, car.Manufacturer, car.Model
                            select car;

            var question3 = cars.Where(c => c.Manufacturer == "BMW")
                                            .OrderByDescending(c => c.BurningInGeneral)
                                            .ThenBy(c => c.Model)
                                            .Select(c => c).First();

            var question4 = (from car in cars
                             where car.Manufacturer == "Audi"
                             orderby car.BurningInGeneral descending, car.Manufacturer, car.Model
                             select car).First();

            var carBMW = new Car
            {
                Year = 2018,
                Manufacturer = "BMW",
                Model = "M4 GTS",
                Capacity = 3.0,
                NumberOfCylinders = 6,
                BurningOnHighway = 16,
                BurningInCity = 19,
                BurningInGeneral = 23
            };

            var carBMW2 = cars[100];

            var question5 = cars.Contains<Car>(carBMW2);
            var question6 = cars.Contains<Car>(carBMW);

            var question7 = cars.Any(c => c.BurningInGeneral == 40);

            foreach (var car in question.Take(10))
            {
                Console.WriteLine("{0,-55} {1,-10}", $"{car.Manufacturer} {car.Model}", car.BurningInGeneral);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.WriteLine("***********************************************************");
            Console.WriteLine($"{question4.Manufacturer} {question4.Model} {question4.BurningInGeneral}");
            Console.WriteLine("***********************************************************");
            Console.WriteLine(question5);
            Console.WriteLine(question6);
            Console.WriteLine(question7);
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
                                          .TakeLineReturnCar().ToList();

        }
    }

    public static class CarExtension
    {
        public static IEnumerable<Car> TakeLineReturnCar(this IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var carProperties = line.Split(',');
                carProperties[3] = carProperties[3].Replace('.', ',');
                yield return new Car
                {
                    Year = int.Parse(carProperties[0]),
                    Manufacturer = carProperties[1],
                    Model = carProperties[2],
                    Capacity = double.Parse(carProperties[3]),
                    NumberOfCylinders = int.Parse(carProperties[4]),
                    BurningInCity = int.Parse(carProperties[5]),
                    BurningOnHighway = int.Parse(carProperties[6]),
                    BurningInGeneral = int.Parse(carProperties[7]),
                };
            }
        }
    }
}
