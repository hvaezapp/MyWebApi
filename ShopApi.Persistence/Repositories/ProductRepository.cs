using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;

namespace ShopApi.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShopApiDbContext _dbContext;

        public ProductRepository(ShopApiDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

 


        public async Task<List<Product>> GetProducts(string filterByName = "", int skip = 0, int take = 10)
        {
            //List<Product> products = new();


            //if (filterBy != null)
            //{
            //    products = await _dbContext.Product
            //                            .Where(a => a.Name.Contains(filterBy.ByName))
            //                            .Skip(skip).Take(take).ToListAsync();
            //}
            //else
            //{
            //    products = await _dbContext.Product
            //                       .Skip(skip).Take(take).ToListAsync();
            //}


            //return products;


            return await _dbContext.Product
                                   .Where(a => a.Name.Contains(filterByName))
                                   .Skip(skip).Take(take).ToListAsync();

        }
    }
}
