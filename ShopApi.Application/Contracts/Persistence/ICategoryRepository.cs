using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategories(int skip = 0, int take = 10);

    }
}
