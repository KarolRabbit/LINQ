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
                new Employee{Id = 5, FirstName = "Karol", LastName = "Gepheld"},
                new Employee{Id = 6, FirstName = "Michał", LastName = "Dmowski"},
                new Employee{Id = 7, FirstName = "Darek", LastName = "Botek"},
                new Employee{Id = 8, FirstName = "Katarzyna", LastName = "Majewska"},
                new Employee{Id = 9, FirstName = "Grzegorz", LastName = "Bager"},
                new Employee{Id = 10, FirstName = "Agnieszka", LastName = "Tanajno"},
                new Employee{Id = 11, FirstName = "Mieczysław", LastName = "Lambert"},
                new Employee{Id = 12, FirstName = "Leopold", LastName = "Wajdel"},
                new Employee{Id = 13, FirstName = "Monika", LastName = "Sas"},
                new Employee{Id = 14, FirstName = "Michał", LastName = "Dworczyk"},
                new Employee{Id = 15, FirstName = "Aleksandra", LastName = "Płotek"},
                new Employee{Id = 16, FirstName = "Vitalij", LastName = "Klichenko"}
            };

            IEnumerable<Employee> drivers = new List<Employee>()
            {
                new Employee{Id = 17, FirstName = "Dominik", LastName = "Rachwalik"},
                new Employee{Id = 18, FirstName = "Rafał", LastName = "Nowak"},
                new Employee{Id = 19, FirstName = "Danuta", LastName = "Karoń"},
            };

            var question = programmers.Where(e => e.FirstName.StartsWith("K"));

            var question2 = from programer in programmers
                            where programer.LastName.Length > 5
                            orderby programer.Id
                            select programer;

            var question3 = programmers.Where(p => p.FirstName.EndsWith("a")).OrderByDescending(p => p.Id);

            var question4 = from programer in programmers
                            where (programer.Id < 10 && programer.Id > 5)
                            orderby programer.LastName descending
                            select programer.LastName;

            var question5 = programmers.Where(p => (p.LastName.Length > 5 && p.FirstName.Length > 5)).OrderBy(p => p.Id).Select(p => p.LastName);

            foreach (var person in question)
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
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var person in question2)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName} nr ID: {person.Id}.");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var person in question3)
            {
                Console.WriteLine($" nr ID:{person.Id} {person.LastName} {person.FirstName}.");
            }
            
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var lastName in question4)
            {
                Console.WriteLine(lastName);
            }
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var lastName in question5)
            {
                Console.WriteLine(lastName);
            }
            Console.ReadKey();
        }

        private static bool StartsLetter(Employee employee)
        {
            return employee.FirstName.StartsWith("K");
        }
    }
}
