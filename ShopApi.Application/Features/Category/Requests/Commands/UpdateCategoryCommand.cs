using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;

namespace ShopApi.Application.Features.Category.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
