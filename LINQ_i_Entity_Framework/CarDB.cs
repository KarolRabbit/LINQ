using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Filtrowanie_sortowanie_wyswietlanie;

namespace LINQ_i_Entity_Framework
{
    public class CarDB : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
