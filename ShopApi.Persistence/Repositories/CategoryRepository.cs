using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;

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




        public Task<List<Category>> GetCategories(FilterBy filterBy = null, int pageNom = 1)
        {
            throw new NotImplementedException();
        }
    }
}
