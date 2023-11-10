using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Category.Requests.Queries
{
    public class GetCategoryByIdRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
