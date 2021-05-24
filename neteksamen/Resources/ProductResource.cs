using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Resources
{
    public class ProductResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int AmountInPackage { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public CategoryResource Category { get; set; }
        public SupplierResource Supplier { get; set; }
    }
}
