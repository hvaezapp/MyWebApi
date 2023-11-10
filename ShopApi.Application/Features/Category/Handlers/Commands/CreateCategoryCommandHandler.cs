using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Responses;
using ShopApi.Application.DTOs.Category.Validators;


namespace ShopApi.Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new CreateCategoryValidator();

            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {

                var category = _mapper.Map<Domain.Entity.Category>(request.CreateCategoryDto);
                category = await _categoryRepository.Add(category);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}
