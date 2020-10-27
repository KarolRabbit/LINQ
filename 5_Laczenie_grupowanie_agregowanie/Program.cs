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


            var question6 = from manufacturer in manufacturers
                            join car in cars on manufacturer.Name equals car.Manufacturer into groupCars
                            orderby manufacturer.Headquarters
                            select new
                            {
                                Manufacturer = manufacturer,
                                Cars = groupCars
                            } into result
                            group result by result.Manufacturer.Headquarters;
                            
                            

            foreach (var country in question6)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"{country.Key}");

                foreach (var car in country.SelectMany(g => g.Cars).OrderByDescending(c=>c.BurningInGeneral).Take(3))
                {
                    Console.WriteLine("{0,-55} {1,-10}", $"{car.Manufacturer} {car.Model}", car.BurningInGeneral);
                }
                Console.WriteLine("--------------------------------------------------------\n");
            }



            //var question5 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
            //                                             (m, g) =>
            //                                                      new
            //                                                      {
            //                                                          Manufacturer = m,
            //                                                          Cars = g
            //                                                      }).OrderBy(m => m.Manufacturer.Name);

            //foreach (var carsGroup in question5)
            //{
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine($"{carsGroup.Manufacturer.Name} from {carsGroup.Manufacturer.Headquarters}");
            //    foreach (var car in carsGroup.Cars.OrderByDescending(c => c.BurningInGeneral).Take(3))
            //    {
            //        Console.WriteLine($"\t{car.Model,-35} {car.BurningInGeneral,-15}");
            //    }
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine("\n");
            //}

            //var question4 = from manufacturer in manufacturers
            //                join car in cars on manufacturer.Name equals car.Manufacturer into groupCars
            //                orderby manufacturer.Name
            //                select new
            //                {
            //                    Cars = groupCars,
            //                    Manufacturer = manufacturer
            //                };

            //foreach (var carsGroup in question4)
            //{
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine($"{carsGroup.Manufacturer.Name} from {carsGroup.Manufacturer.Headquarters}");
            //    foreach (var car in carsGroup.Cars.OrderByDescending(c => c.BurningInGeneral).Take(3))
            //    {
            //        Console.WriteLine($"\t{car.Model,-35} {car.BurningInGeneral,-15}");
            //    }
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine("\n");
            //}



            //var question2 = cars.GroupBy(c => c.Manufacturer)
            //                    .OrderBy(g => g.Key)
            //                    .Select(g => g);

            //foreach (var group in question2)
            //{
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine($"{group.Key}");
            //    Console.WriteLine("- - - - - - - - - - - - - - -  - - - - - - - - - - - - - ");
            //    foreach (var car in group.OrderByDescending(c => c.BurningInGeneral).Take(4))
            //    {
            //        Console.WriteLine($"\t--> {car.Model,-40} {car.BurningInGeneral,-10}");
            //    }
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine();
            //}

            //SKŁADNIA ZAPYTANIA
            //var question = from car in cars
            //               group car by car.Manufacturer.ToUpper() into manufacturer
            //               orderby manufacturer.Key
            //               select manufacturer;

            //foreach (var group in question)
            //{
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine($"{group.Key}");
            //    Console.WriteLine("- - - - - - - - - - - - - - -  - - - - - - - - - - - - - ");
            //    foreach (var car in group.OrderByDescending(c => c.BurningInGeneral).Take(4))
            //    {
            //        Console.WriteLine($"\t--> {car.Model,-40} {car.BurningInGeneral,-10}");
            //    }
            //    Console.WriteLine("--------------------------------------------------------");
            //    Console.WriteLine();
            //}

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
