using FluentValidation;

namespace ShopApi.Application.DTOs.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");



            RuleFor(p => p.CategoryId).NotNull()
            .WithMessage("{PropertyName} is required.");
        }
    }
}
