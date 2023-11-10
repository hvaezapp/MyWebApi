using AutoMapper;
using FluentValidation;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category.Validators;
using ShopApi.Application.DTOs.Product.Validators;
using ShopApi.Application.Features.Product.Requests.Commands;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new CreateProductValidator();

            var validationResult = await validator.ValidateAsync(request.CreateProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {

                var category = _mapper.Map<Domain.Entity.Product>(request.CreateProductDto);
                category = await _productRepository.Add(category);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}
