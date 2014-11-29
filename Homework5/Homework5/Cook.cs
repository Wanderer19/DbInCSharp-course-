using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Cook : Man
    {
        public int Salary { get; set; }
        public int Experience { get; set; }
        public string Address { get; set; }

        [ForeignKey("Bakery")]
        public int BakeryId { get; set; }

        public virtual Bakery Bakery { get; set; }
    }
}
