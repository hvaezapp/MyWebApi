using FluentValidation;

namespace ShopApi.Application.DTOs.Category.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required.");



            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");



        }
    }
}
