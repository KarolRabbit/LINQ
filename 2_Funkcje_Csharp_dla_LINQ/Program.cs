using System;
using System.Collections.Generic;
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
            IEnumerable<Employee> programmers = new Employee[]
            {
                new Employee{Id = 1, FirstName = "Karol", LastName = "Królik"},
                new Employee{Id = 2, FirstName = "Michał", LastName = "Ciemniok"},
                new Employee{Id = 3, FirstName = "Damian", LastName = "Bambaryła"},
                new Employee{Id = 4, FirstName = "Anna", LastName = "Kolka"},
            };

            IEnumerable<Employee> drivers = new List<Employee>()
            {
                new Employee{Id = 5, FirstName = "Dominik", LastName = "Rachwalik"},
                new Employee{Id = 6, FirstName = "Rafał", LastName = "Nowak"},
                new Employee{Id = 7, FirstName = "Danuta", LastName = "Karoń"},
            };

            Console.WriteLine(MyLinq.Count(drivers));
            Console.WriteLine(programmers.Count());

            IEnumerator<Employee> enumerator = drivers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.FirstName);
            }

            Console.ReadKey();
        }



    }
}
