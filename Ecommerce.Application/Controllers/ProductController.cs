using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Data.DTOs.ProductDtos;
using Ecommerce.Application.Profiles;
using Ecommerce.Data.Entities;

namespace Ecommerce.Application.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpPost, Route("insert")]

        public async Task<IActionResult> InsertProduct(ProductInsertDto productInsertDto)
        {
            {
                try
                {
                    var insertedProduct = ObjectMapper.Mapper.Map<Product>(productInsertDto);
                    await _productRepository.Insert(insertedProduct);
                    return Ok($"The product {insertedProduct.Name} has been inserted.");

                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception while inserting product ", ex.Message);
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            try
            {
                var updatedProduct = ObjectMapper.Mapper.Map<Product>(productUpdateDto);
                await _productRepository.Update(updatedProduct);
                return Ok("Product Updated");
            }catch(Exception ex)
            {
                _logger.LogError("Exception while updating product ", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("delete")]
        public async Task<IActionResult> DeleteProduct(ProductDeleteDto productDeleteDto)
        {
            try
            {
                var deletedBlock = ObjectMapper.Mapper.Map<Product>(productDeleteDto).Id;
                await _productRepository.DeleteById(deletedBlock);
                return Ok("Product Deleted");

            }catch(Exception ex)
            {
                _logger.LogError("Exception while deleting product ", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get-all")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {

                IEnumerable<Product> allProduct = await _productRepository.GetAll();
                IEnumerable<ProductDto> data = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(allProduct);
                return Ok(data);
            }catch(Exception ex)
            {
                _logger.LogError("Exception while getting all products", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                ProductDto productDto = ObjectMapper.Mapper.Map<ProductDto>(await _productRepository.GetProduct(id));
                return Ok(productDto);
            }catch(Exception ex)
            {
                _logger.LogError("Exception while retrieving single product ", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
