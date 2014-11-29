using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Man
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public int Age { get; set; }

        public IEnumerable<Bakery> Bakeries { get; set; } 
    }
}
