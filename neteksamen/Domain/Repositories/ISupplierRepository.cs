using neteksamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task AddAsync(Supplier supplier);
        Task<Supplier> FindByIdAsync(int id);
        void Update(Supplier supplier);
        void Remove(Supplier supplier);
    }
}
