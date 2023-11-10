using MediatR;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Product.Requests.Queries
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
        public int PageNom { get; set; }
        public FilterBy FilterBy { get; set; }
    }
}
