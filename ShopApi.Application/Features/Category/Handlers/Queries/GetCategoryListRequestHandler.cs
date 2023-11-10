using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Requests.Queries;

namespace ShopApi.Application.Features.Category.Handlers.Queries
{


    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<ProductDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;




        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task<List<ProductDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategories(request.PageNom , request.FilterByName);
            return _mapper.Map<List<ProductDto>>(categories);
        }
    }
}
