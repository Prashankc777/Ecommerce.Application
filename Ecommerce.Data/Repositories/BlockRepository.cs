using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repositories
{

    public interface IBlockRepository
    {
        Task<Block> Insert(Block block);
        Task Update(Block block);
        Task<Block> GetById(int id);
        Task<IEnumerable<Block>> GetAll();
        Task Delete(int id);
    }
    internal class BlockRepository : IBlockRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlockRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Block> Insert(Block block)
        {
            await _appDbContext.AddAsync(block);
            await _appDbContext.SaveChangesAsync();
            return block;
        }

        public async Task Update(Block block)
        {
            Block blockToUpdate = await _appDbContext.Blocks.SingleAsync(x => x.Id == block.Id);

            blockToUpdate.Alias = block.Alias;

            await _appDbContext.SaveChangesAsync();
            
        }

        public async Task<Block> GetById(int id)
        {

            return await _appDbContext.Blocks.SingleAsync(x => x.Id == id);
            
        }

        public async Task<IEnumerable<Block>> GetAll()
        {
            return await _appDbContext.Blocks.AsNoTracking().ToListAsync();
        }

        public async Task Delete(int id)
        {
            Block blockToDelete = await _appDbContext.Blocks.SingleAsync(x => x.Id == id);
            
            _appDbContext.Blocks.Remove(blockToDelete);
            await _appDbContext.SaveChangesAsync();


        }
    }
}
