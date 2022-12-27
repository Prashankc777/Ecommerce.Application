using AutoMapper.Internal.Mappers;
using Ecommerce.Application.Profiles;
using Ecommerce.Data.DTOs;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<VendorController> _logger;

        
        public VendorController(IVendorRepository vendorRepository, ILogger<VendorController> logger)
        {
            _vendorRepository= vendorRepository;
            _logger= logger;
        }

        [HttpPost, Route("insert")]
        public async Task<IActionResult> InsertVendor(VendorInsertDto vendorInsertDto)
        {
            try
            {
                var insertVendor = ObjectMapper.Mapper.Map<Vendor>(vendorInsertDto);
                var insertedVendor = await _vendorRepository.Insert(insertVendor);
                return Ok($"Vendor {insertedVendor} inserted");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get-all")]
        public async Task<IActionResult> GetAllVendors()
        {
            try
            {
                IEnumerable<Vendor> getAllVendor = await _vendorRepository.GetAll();
                var getVendor = ObjectMapper.Mapper.Map<IEnumerable<VendorDto>>(getAllVendor);
                
                return Ok(getVendor);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("update")]

        public async Task<IActionResult> UpdateVendors(VendorUpdateDto vendorUpdateDto)
        {
            try
            {
                var vendorMap = ObjectMapper.Mapper.Map<Vendor>(vendorUpdateDto);
                await _vendorRepository.Update(vendorMap);
                return Ok("Vendor Updated!");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet, Route("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var vendorMap = await _vendorRepository.GetById(id);
                VendorDto vendorDto = ObjectMapper.Mapper.Map<VendorDto>(vendorMap);
                return Ok(vendorDto);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("delete")]

        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _vendorRepository.Delete(id);
                
                return Ok("Deleted");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
