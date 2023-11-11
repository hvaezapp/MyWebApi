using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category.Validators;
using ShopApi.Application.Exceptions;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Responses;

namespace ShopApi.Application.Features.Category.Handlers.Commands
{
    public class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateCategoryValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);

                category.Name = request.UpdateCategoryDto.Name;

                await _categoryRepository.Update(category);
                await _categoryRepository.SaveChanges();


                response.Success = true;
                response.Message = "Update Successful";
                response.Id = category.Id;
            }

               

            return response;
        }
    }
}
