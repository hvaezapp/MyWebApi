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

        public Task<List<Category>> GetProducts(FilterBy filterBy = null, int pageNom = 1)
        {
            throw new NotImplementedException();
        }
    }
}
