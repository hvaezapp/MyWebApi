using MediatR;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Product.Requests.Queries
{
    public class GetProductByIdRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
