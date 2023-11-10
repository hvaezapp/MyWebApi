﻿using MediatR;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Category.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}