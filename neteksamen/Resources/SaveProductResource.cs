using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Desc { get; set; }
        [Required]
        [Range(1,5)]
        public int UnitOfMeasurement { get; set; }
        [Required]
        public int AmountInPackage { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
