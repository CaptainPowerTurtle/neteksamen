using neteksamen.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int AmountInPackage { get; set; }
        public  decimal Price { get; set; }
        public Category  Category { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
