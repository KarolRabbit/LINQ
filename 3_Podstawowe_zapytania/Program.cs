using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Podstawowe_zapytania
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmList = new List<Film>()
            {
                new Film{Title= "Skazani na Shawshank", Rating=8.76, Year=1994, Type=FilmType.dramat},
                new Film{Title= "Nietykalni", Rating=8.62, Year=2011, Type=FilmType.dramat},
                new Film{Title= "Człowiek z blizną", Rating=8.18, Year=1983, Type=FilmType.dramat},
                new Film{Title= "Obcy - 8. pasażer \"Nostromo\"", Rating=7.79, Year=1979, Type=FilmType.horror},
                new Film{Title= "Shrek", Rating=7.79, Year=2001, Type=FilmType.animowany},
                new Film{Title= "Dzień świra", Rating=7.77, Year=2002, Type=FilmType.komedia},
                new Film{Title= "Patch Adams", Rating=7.61, Year=1998, Type=FilmType.komedia},
                new Film{Title= "Siedem", Rating=8.30, Year=1995, Type=FilmType.thriller},
                new Film{Title= "Wyspa tajemnic", Rating=8.18, Year=2010, Type=FilmType.thriller},
                new Film{Title= "Uśpieni", Rating=7.93, Year=1996, Type=FilmType.thriller},
                new Film{Title= "Jestem legendą", Rating=7.52, Year=2007, Type=FilmType.horror},

            };

            var question1 = filmList.Where(f => f.Year > 2000).OrderByDescending(f => f.Rating).Select(f => f);

            var question2 = filmList.Filtr(f => f.Year > 2000).OrderByDescending(f => f.Year).Select(f => f);

            foreach (var film in question1)
            {
                Console.WriteLine($"{film.Title,-20} {film.Rating,-20}");
            }
            Console.WriteLine("*********************************************************");
            foreach (var film in question2)
            {
                Console.WriteLine($"{film.Title,-20} {film.Year,-20}");
            }
            Console.ReadKey();
        }
    }
}
