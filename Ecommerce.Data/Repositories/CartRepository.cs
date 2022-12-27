using Ecommerce.Data.Entities;
using Ecommerce.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> Insert(Cart cart);
        Task Update(Cart cart);
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> GetById(int id);
        Task Delete(int id);
    }
    internal class CartRepository : ICartRepository
    {
        private readonly AppDbContext _appDbContext;

        public CartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Cart> Insert(Cart cart)
        {
            cart.CreatedDate = GeneralUtility.GetCurrentNepaliDateTime();
            await _appDbContext.AddAsync(cart);
            await _appDbContext.SaveChangesAsync();
            return cart;
        }

        public async Task Update(Cart cart)
        {
            Cart cartUpdated = await _appDbContext.Carts.SingleAsync(x => x.Id == cart.Id);
            cartUpdated.UserId= cart.UserId;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Cart cartToDelete = await _appDbContext.Carts.SingleAsync(x => x.Id == id);

            _appDbContext.Carts.Remove(cartToDelete);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _appDbContext.Carts.AsNoTracking().ToListAsync();
        }

        public Task<Cart> GetById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
