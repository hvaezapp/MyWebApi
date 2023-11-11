using ShopApi.Application.DTOs.Filter;
using ShopApi.Domain.Entity;

namespace ShopApi.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProducts(int skip = 0, int take = 10);
        
    }
}
