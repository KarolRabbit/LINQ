using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Podstawowe_zapytania
{
    public enum FilmType { horror, komedia, dramat, thriller,animowany}
    public class Film
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public FilmType Type { get; set; }
        public double Rating { get; set; }

    }
}
