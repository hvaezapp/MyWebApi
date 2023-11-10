using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category.Validators;
using ShopApi.Application.DTOs.Product.Validators;
using ShopApi.Application.Exceptions;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Features.Product.Requests.Commands;

namespace ShopApi.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateProductDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var category = await _productRepository.Get(request.UpdateProductDto.Id);
            //_mapper.Map(request.UpdateCategoryDto, category);
            await _productRepository.Update(category);


            return Unit.Value;
        }
    }
}
