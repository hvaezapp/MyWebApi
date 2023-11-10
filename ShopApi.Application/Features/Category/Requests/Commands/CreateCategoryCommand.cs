using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Category.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
