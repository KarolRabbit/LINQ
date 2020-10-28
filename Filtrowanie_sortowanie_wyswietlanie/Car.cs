using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtrowanie_sortowanie_wyswietlanie
{
    public class Car
    {
        public int Id { get; set; }

        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        public int NumberOfCylinders { get; set; }
        public int BurningInCity { get; set; }
        public int BurningOnHighway { get; set; }
        public int BurningInGeneral { get; set; }

        public static Car TransformCSV(string line)
        {
            var carProperties = line.Split(',');
            carProperties[3] = carProperties[3].Replace('.', ',');
            return new Car
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
