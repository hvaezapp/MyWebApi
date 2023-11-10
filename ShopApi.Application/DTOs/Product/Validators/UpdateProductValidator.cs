using FluentValidation;

namespace ShopApi.Application.DTOs.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required.");



            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");

        }
    }
}
