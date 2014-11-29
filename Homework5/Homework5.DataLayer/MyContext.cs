using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DataLayer
{
    public class MyContext : DbContext
    {
        public DbSet<Bakery> Bakeries { get; set; }
        public DbSet<Man> Men { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
    }
}
