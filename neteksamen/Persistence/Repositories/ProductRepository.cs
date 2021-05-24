using Microsoft.EntityFrameworkCore;
using neteksamen.Domain.Repositories;
using neteksamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Supplier)
                                          .ToListAsync();
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
