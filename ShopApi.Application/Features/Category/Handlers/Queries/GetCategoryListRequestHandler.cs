using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Category.Requests.Queries;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Features.Category.Handlers.Queries
{


    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;




        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            int skip = (request.PageNom * 10) - 1;

            var categories = await _categoryRepository.GetCategories(request.FilterByName  , skip ,  DefaultConst.TakeCount );
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
