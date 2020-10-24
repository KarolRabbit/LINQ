using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3_Podstawowe_zapytania
{
    public static class MyLinq
    {
        public static IEnumerable<T> Filtr<T>(this IEnumerable<T> collection, Func<T,bool> predicate)
        {
            List<T> results = new List<T>();

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    results.Add(item);
                }
            }
            return results;
        }
    }
}
