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
            var cars2 = ReadFilesQuestion("paliwo.csv");

            foreach (var car in cars2)
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
