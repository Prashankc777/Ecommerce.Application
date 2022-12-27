using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public interface IVendorRepository
    {
        Task<string> Insert(Vendor vendor);
        Task <IEnumerable<Vendor>> GetAll();
        Task Update(Vendor vendor);
        Task<Vendor> GetById(int id);
        Task Delete(int id);
    }
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _appDbContext;

        public VendorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Insert(Vendor vendor)
        {
            EntityEntry<Vendor> insertedVendor = await _appDbContext.AddAsync(vendor);
            await _appDbContext.SaveChangesAsync();
            return insertedVendor.Entity.Name;
        }

        public async Task<IEnumerable<Vendor>> GetAll()
        {
            return await _appDbContext.Vendors.AsNoTracking().ToListAsync();
        }

        public async Task Update(Vendor vendor)
        {
            Vendor vendorToUpdate = await _appDbContext.Vendors.SingleAsync(x => x.Id == vendor.Id);
            vendorToUpdate.Name = vendor.Name;
            vendorToUpdate.Address = vendor.Address;
            vendorToUpdate.Contact= vendor.Contact;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Vendor> GetById(int id)
        {
            return await _appDbContext.Vendors.AsNoTracking().SingleAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var vendorDelete = await _appDbContext.Vendors.SingleAsync(x => x.Id == id);
            _appDbContext.Vendors.Remove(vendorDelete);
            await _appDbContext.SaveChangesAsync();
            //_appDbContext.SaveChanges();
        }
    }
}
