using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_Laczenie_grupowanie_agregowanie;
using System.IO;
using Filtrowanie_sortowanie_wyswietlanie;
using System.Xml.Linq;
using _6_LINQ__do_XML;
using System.Data.Entity;

namespace LINQ_i_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDB>());
            InsertData();
            QuestionData();

            Console.ReadLine();
        }

        private static void InsertData()
        {
            var cars = ReadFiles("paliwo.csv");
            var db = new CarDB();

            if(!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static void QuestionData()
        {
            var db = new CarDB();
            var question = from car in db.Cars
                           orderby car.BurningInGeneral descending, car.Manufacturer ascending
                           select car;

            foreach (var car in question.Take(10))
            {
                Console.WriteLine("{0,-55} {1,-10}", $"{car.Manufacturer} {car.Model}", car.BurningInGeneral);
            }
                           
        }

        private static void AskXML()
        {
            var document = XDocument.Load("paliwo.xml");

            var questionToXML = from element in document.Element("Cars").Elements("Car")
                                where element.Attribute("Manufacturer").Value == "BMW"
                                select new
                                {
                                    Model = element.Attribute("Model").Value,
                                    Manufacturer = element.Attribute("Manufacturer").Value,
                                    GeneralBurning = element.Attribute("BurningInGeneral").Value
                                };

            foreach (var item in questionToXML.OrderByDescending(i => i.GeneralBurning))
            {
                Console.WriteLine("{0,-55} {1,-10}", $"{item.Manufacturer} {item.Model}", item.GeneralBurning);
            }

            Console.ReadKey();
        }

        private static void NewXML()
        {
            var cars = ReadFiles("paliwo.csv");
            //var manufacturers = ReadManufacturers("producent.csv");

            var document = new XDocument();
            var carsXML = new XElement("Cars", from car in cars
                                               select new XElement("Car",
                                                                 new XAttribute("Model", car.Model),
                                                                 new XAttribute("Manufacturer", car.Manufacturer),
                                                                 new XAttribute("Capacity", car.Capacity),
                                                                 new XAttribute("BurningInGeneral", car.BurningInGeneral),
                                                                 new XAttribute("BurningOnHighway", car.BurningOnHighway),
                                                                 new XAttribute("BurningInCity", car.BurningInCity)));
            document.Add(carsXML);
            document.Save("paliwo.xml");

            //foreach (var car in cars)
            //{
            //    var carProperty = new XElement("CarProperty",
            //                                         new XAttribute("Model", car.Model),
            //                                         new XAttribute("Manufacturer", car.Manufacturer),
            //                                         new XAttribute("BurningInGeneral", car.BurningInGeneral),
            //                                         new XAttribute("BurningInCity", car.BurningInCity ));


            //    carsXML.Add(carProperty);
            //}

            //document.Add(carsXML);
            //document.Save("paliwo.xml");
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
