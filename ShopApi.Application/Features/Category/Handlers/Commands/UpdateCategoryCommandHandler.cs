using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category.Validators;
using ShopApi.Application.Exceptions;
using ShopApi.Application.Features.Category.Requests.Commands;


namespace ShopApi.Application.Features.Category.Handlers.Commands
{
    public class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateCategoryValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);
            //_mapper.Map(request.UpdateCategoryDto, category);
            await _categoryRepository.Update(category);


            return Unit.Value;
        }
    }
}
