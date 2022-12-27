using Ecommerce.Application.Profiles;
using Ecommerce.Data.DTOs;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartRepository cartRepository, ILogger<CartController> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        [HttpPost, Route("insert")]
        public async Task<IActionResult> Insert(CartInsertDto cartInsertDto)
        {
           var cartMap = ObjectMapper.Mapper.Map<Cart>(cartInsertDto);
            var insertedCart = await _cartRepository.Insert(cartMap);
            return Ok($"Cart {insertedCart} has been inserted");
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> Update(CartUpdateDto cartUpdateDto)
        {
            await _cartRepository.Update(ObjectMapper.Mapper.Map<Cart>(cartUpdateDto));
            return Ok("Cart Updated");
        }

        [HttpPost, Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cartRepository.Delete(id);
            return Ok("Cart Deleted");
        }

        [HttpGet, Route("get-all")]
        public async Task<IActionResult> GetAll()
        {

        }
    }
}
