using MediatR;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Category.Requests.Queries
{
    public class GetCategoryByIdRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
