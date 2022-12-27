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
    public interface IProductRepository
    {
        Task<Product> Insert(Product product);
        Task Update(Product product);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetAll();
        Task DeleteById(int id);
    }
    internal class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> Insert(Product product)
        {
            product.CreatedDate = GeneralUtility.GetCurrentNepaliDateTime();
            product.CreatedBy = "Renish";
            await _appDbContext.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            Product productToUpdate = await _appDbContext.Products.SingleAsync(x => x.Id == product.Id);
            productToUpdate.Name= product.Name;
            productToUpdate.IsActive = true;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appDbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _appDbContext.Products.SingleAsync(x => x.Id == id);
        }
        public async Task DeleteById(int id)
        {
            Product productToDelete = await _appDbContext.Products.SingleAsync(x => x.Id == id);

            _appDbContext.Products.Remove(productToDelete);
            await _appDbContext.SaveChangesAsync();
        }
    }
}