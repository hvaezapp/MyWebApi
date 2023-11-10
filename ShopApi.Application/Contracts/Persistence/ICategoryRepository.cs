using ShopApi.Domain.Entity;

namespace ShopApi.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategories(int page = 1 , string filterbyname = "");
    }
}
