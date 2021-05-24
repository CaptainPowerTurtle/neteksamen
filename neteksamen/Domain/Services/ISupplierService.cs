using neteksamen.Domain.Services.Communication;
using neteksamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Domain.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<SupplierResponse> ListByIdAsync(int id);
        Task<SupplierResponse> SaveAsync(Supplier supplier);
        Task<SupplierResponse> UpdateAsync(int id, Supplier supplier);
        Task<SupplierResponse> DeleteAsync(int id);
    }
}
