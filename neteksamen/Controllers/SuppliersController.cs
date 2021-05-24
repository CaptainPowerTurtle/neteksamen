using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using neteksamen.Domain.Services;
using neteksamen.Extensions;
using neteksamen.model;
using neteksamen.Resources;

namespace neteksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<SupplierResource>> GetAllAsync()
        {
            var suppliers = await _supplierService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
            var result = await _supplierService.SaveAsync(supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Supplier);
            return Ok(supplierResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
            var result = await _supplierService.UpdateAsync(id, supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Supplier);
            return Ok(supplierResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _supplierService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Supplier);
            return Ok(supplierResource);
        }
    }
}
