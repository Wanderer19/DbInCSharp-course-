using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework5.DataLayer;

namespace Homework5.App
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                context.Bakeries.Add(new Bakery() {Id = 2, Address = "adr2", Income = 1000, Name = "Bakery2"});
                context.SaveChanges();
            }
        }
    }
}
