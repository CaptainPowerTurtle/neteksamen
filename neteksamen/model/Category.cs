using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.model
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
