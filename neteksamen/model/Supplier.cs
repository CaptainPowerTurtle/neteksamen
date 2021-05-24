using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.model
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
