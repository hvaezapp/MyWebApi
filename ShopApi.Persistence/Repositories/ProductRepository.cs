using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Contracts.Persistence;
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




        public async Task<List<Product>> GetProducts(int skip = 0, int take = 10)
        {
            return await _dbContext.Product
                              .Skip(skip).Take(take).ToListAsync();
        }
    }
}
