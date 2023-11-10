using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Category.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {

        public int PageNom { get; set; }
        //public FilterBy FilterBy { get; set; }
        public string FilterByName { get; set; }

    }
}
