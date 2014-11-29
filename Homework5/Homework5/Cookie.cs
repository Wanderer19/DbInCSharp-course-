using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework5.Enums;

namespace Homework5
{
    public class Cookie
    {
        [Key]
        public int Id { get; set; }

        public CookieTastes Taste { get; set; }
        public CookieColor Color { get; set; }
        public int Price { get; set; }
        public IEnumerable<Bakery> Bakeries { get; set; } 
    }
}
