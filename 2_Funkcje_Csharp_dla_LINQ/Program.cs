using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Funkcje_Csharp_dla_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------FUNC i ACTION-----------------------------------------------
            double x = 5.5;
            Func<double, double> square = (d => d * d);
            Console.WriteLine($"Kwadrat z {x} jest równy {square(x)}");
            double y = 25;
            Func<double, double> squareRoot = (d => Math.Sqrt(d));
            Console.WriteLine($"Pierwiastek kwadratowy z {y} jest równy {squareRoot(y)}");
            string yourName = "Daniel";
            Action<string> sayHello = (n => Console.WriteLine($"Osoba którą witamy to {n}"));
            sayHello(yourName);
            Console.WriteLine("-------------------------------------------------------------------");
    //-------------------------------------------------------------------

            IEnumerable<Employee> programmers = new Employee[]
            {
                new Employee{Id = 1, FirstName = "Karol", LastName = "Królik"},
                new Employee{Id = 2, FirstName = "Michał", LastName = "Ciemniok"},
                new Employee{Id = 3, FirstName = "Damian", LastName = "Bambaryła"},
                new Employee{Id = 4, FirstName = "Anna", LastName = "Kolka"},
                new Employee{Id = 1, FirstName = "Karol", LastName = "Gepheld"},
                new Employee{Id = 2, FirstName = "Michał", LastName = "Dmowski"},
                new Employee{Id = 3, FirstName = "Darek", LastName = "Botek"},
                new Employee{Id = 4, FirstName = "Katarzyna", LastName = "Majewska"}
            };

            IEnumerable<Employee> drivers = new List<Employee>()
            {
                new Employee{Id = 5, FirstName = "Dominik", LastName = "Rachwalik"},
                new Employee{Id = 6, FirstName = "Rafał", LastName = "Nowak"},
                new Employee{Id = 7, FirstName = "Danuta", LastName = "Karoń"},
            };

            foreach (var person in programmers.Where(e => e.FirstName.StartsWith("K")))
            {
                Console.WriteLine(person.FirstName);
            }
            Console.WriteLine("-------------------------------------------------------------------");
            //---------------------Dodatkowe---------------------------------------------------
            foreach (var person in programmers.Where(p => p.FirstName.Length == 6).OrderBy(p => p.LastName))
            {
                Console.WriteLine($"{person.LastName} {person.FirstName} nr ID: {person.Id}.");
            }
            //---------------------------------------------------------------------------------
            Console.ReadKey();
        }

        private static bool StartsLetter(Employee employee)
        {
            return employee.FirstName.StartsWith("K");
        }
    }
}
