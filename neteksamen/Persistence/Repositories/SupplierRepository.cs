using Microsoft.EntityFrameworkCore;
using neteksamen.Domain.Repositories;
using neteksamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
        }
        public async Task<Supplier> FindByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
        }
        public void Remove(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }
    }
}
