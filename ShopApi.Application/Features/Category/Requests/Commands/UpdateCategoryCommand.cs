using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Category.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
