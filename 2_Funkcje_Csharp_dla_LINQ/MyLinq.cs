using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Funkcje_Csharp_dla_LINQ
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> collection)
        {
            int licznik = 0;
            foreach (var item in collection)
            {
                licznik++;
            }
            return licznik;
        }
    }
}
