using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category.Validators;
using ShopApi.Application.DTOs.Product.Validators;
using ShopApi.Application.Exceptions;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Features.Product.Requests.Commands;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var product = await _productRepository.Get(request.UpdateProductDto.Id);

                product.Name = request.UpdateProductDto.Name;
                product.CategoryId = request.UpdateProductDto.CategoryId;

                await _productRepository.Update(product);
                await _productRepository.SaveChanges();


                response.Success = true;
                response.Message = "Update Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}
