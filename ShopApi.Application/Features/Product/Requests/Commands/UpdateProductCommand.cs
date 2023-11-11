using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<BaseCommandResponse>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
