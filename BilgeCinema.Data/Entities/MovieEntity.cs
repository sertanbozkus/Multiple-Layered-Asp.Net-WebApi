using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeCinema.Data.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
