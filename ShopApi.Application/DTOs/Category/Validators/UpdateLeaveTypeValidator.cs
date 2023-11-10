using FluentValidation;
using ShopApi.Application.DTOs.Category;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateLeaveTypeValidator()
        {

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required.");



            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");

        }
    }
}
