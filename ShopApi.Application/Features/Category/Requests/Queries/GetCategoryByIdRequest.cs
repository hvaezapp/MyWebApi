using MediatR;
using ShopApi.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Category.Requests.Queries
{
    public class GetCategoryByIdRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
