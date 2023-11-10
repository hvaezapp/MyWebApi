using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategories(string filterByName = "", int skip = 0, int take = 10);

        //Task<List<Category>> GetCategories(FilterBy filterBy  = null , int skip = 0  , int take = 10);
    }
}
