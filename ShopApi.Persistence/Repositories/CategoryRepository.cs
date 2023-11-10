using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;
using System.Collections.Generic;

namespace ShopApi.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ShopApiDbContext _dbContext;

        public CategoryRepository(ShopApiDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }




        public async Task<List<Category>> GetCategories(string filterByName = "", int skip = 0, int take  = 10)
        {
            List<Category> categories = new();


            if (string.IsNullOrEmpty(filterByName))
            {
                categories = await _dbContext.Category
                                        .Where(a => a.Name.Contains(filterByName))
                                        .Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                categories = await _dbContext.Category
                                   .Skip(skip).Take(take).ToListAsync();
            }


            //return            await _dbContext.Category
            //                        .Where(a => a.Name.Contains(filterByName))
            //                        .Skip(skip).Take(take).ToListAsync();



            return categories;

        }                                  
    }
}
