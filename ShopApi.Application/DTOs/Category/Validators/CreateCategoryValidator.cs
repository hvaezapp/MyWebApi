﻿using FluentValidation;
using ShopApi.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApi.Application.DTOs.Category.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");


        }
    }
}
