using Dapper;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Utilities;

namespace Ecommerce.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Insert(Category category);
        Task Update(Category category);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAll();
        Task Delete(int id);
    }
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConnectionFactory _connectionFactory;

        public CategoryRepository(AppDbContext appDbContext, IConnectionFactory connectionFactory)
        {
            _appDbContext = appDbContext;
            _connectionFactory = connectionFactory;
        }

        public async Task<Category> Insert(Category category)
        {
            category.CreatedDate = GeneralUtility.GetCurrentNepaliDateTime();
            category.CreatedBy = "Renish";
            await _appDbContext.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }
        public async Task Delete(int id)
        {
            try
            {
                using var conn = _connectionFactory.GetConnection;
                const string query = "Delete from Category where Id = @Id";
                var param = new DynamicParameters();
                param.Add("@Id", id);
                await conn.ExecuteAsync(query, param, commandType: CommandType.Text);
            }
            catch(Exception ex) 
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using var conn = _connectionFactory.GetConnection;
            const string query = "Select * from category order BY Id desc";
            return await conn.QueryAsync<Category>(query,  commandType: CommandType.Text);

        }

        public async Task<Category> GetById(int Id)
        {
            // Select* from category c where c.Id = @Id

            using var conn = _connectionFactory.GetConnection;
            const string query = "Select * from category c where c.Id = @Id";
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return await conn.QueryFirstOrDefaultAsync<Category>(query, param: param, commandType: CommandType.Text);
        }

        public async Task Update(Category category)
        {
            //using var conn = _connectionFactory.GetConnection;
            //const string query = "Update category c Set c.Name = @Name Where c.Id = @Id";
            //var param = new DynamicParameters();
            //param.Add("@Id", category.Id);
            //param.Add("@Name", category.Name);

            Category categoryToUpdate = await _appDbContext.Categories.SingleAsync(x => x.Id == category.Id);

            categoryToUpdate.ModifiedDate= GeneralUtility.GetCurrentNepaliDateTime();

            categoryToUpdate.IsActive= true;

            categoryToUpdate.Name = category.Name;

            categoryToUpdate.Alias = category.Alias;

            await _appDbContext.SaveChangesAsync();

        }
    }
}
