using neteksamen.Domain.Repositories;
using neteksamen.Domain.Services;
using neteksamen.Domain.Services.Communication;
using neteksamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _supplierRepository.ListAsync();
        }
        public async Task<SupplierResponse> SaveAsync(Supplier supplier)
        {
            try
            {
                await _supplierRepository.AddAsync(supplier);
                await _unitOfWork.CompleteAsync();

                return new SupplierResponse(supplier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when saving the supplier: {ex.Message}");
            }
        }
        public async Task<SupplierResponse> UpdateAsync(int id, Supplier supplier)
        {
            var existingSupplier = await _supplierRepository.FindByIdAsync(id);

            if (existingSupplier == null)
                return new SupplierResponse("Supplier not found.");

            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.ZipCode = supplier.ZipCode;
            existingSupplier.ContactPerson = supplier.ContactPerson;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Phone = supplier.Phone;

            try
            {
                _supplierRepository.Update(existingSupplier);
                await _unitOfWork.CompleteAsync();

                return new SupplierResponse(existingSupplier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when updating the supplier: {ex.Message}");
            }
        }
        public async Task<SupplierResponse> DeleteAsync(int id)
        {
            var existingSupplier = await _supplierRepository.FindByIdAsync(id);

            if (existingSupplier == null)
                return new SupplierResponse("Supplier not found.");

            try
            {
                _supplierRepository.Remove(existingSupplier);
                await _unitOfWork.CompleteAsync();

                return new SupplierResponse(existingSupplier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when deleting the supplier: {ex.Message}");
            }
        }
    }
}
