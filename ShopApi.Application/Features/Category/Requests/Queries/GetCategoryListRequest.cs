using MediatR;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Category.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<ProductDto>>
    {
        public int PageNom { get; set; }
        public string FilterByName { get; set; }
    }
}
