using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_Laczenie_grupowanie_agregowanie;
using System.IO;
using Filtrowanie_sortowanie_wyswietlanie;
using System.Xml.Linq;

namespace _6_LINQ__do_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ReadFiles("paliwo.csv");
            //var manufacturers = ReadManufacturers("producent.csv");

            var document = new XDocument();
            var carsXML = new XElement("Cars");

            foreach (var car in cars)
            {
                var carProperty = new XElement("CarProperty");
                var model = new XElement("Model", car.Model);
                var manufacturer = new XElement("Manufacturer", car.Manufacturer);
                var burningInGeneral = new XElement("BurningInGeneral", car.BurningInGeneral);

                carProperty.Add(manufacturer);
                carProperty.Add(model);
                carProperty.Add(burningInGeneral);

                carsXML.Add(carProperty);
            }

            document.Add(carsXML);
            document.Save("paliwo.xml");
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
