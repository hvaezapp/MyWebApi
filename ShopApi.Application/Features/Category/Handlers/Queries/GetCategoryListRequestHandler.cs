using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Category.Requests.Queries;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Features.Category.Handlers.Queries
{


    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private const string categoryListCacheKey = "categoryList";

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
  
        private readonly IMemoryCache _cache;



        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository
            , IMapper mapper , IMemoryCache cache )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            // paging
            int skip = (request.PageNom - 1) * 10;

            //var categories = await _categoryRepository.GetCategories(request.FilterByName  , skip ,  DefaultConst.TakeCount );
            //return _mapper.Map<List<CategoryDto>>(categories);




            if (_cache.TryGetValue(categoryListCacheKey, out List<Domain.Entity.Category> categories))
            {
                //categories = cashedCategories.Skip(skip).Take(DefaultConst.TakeCount).ToList();
                //categories = cashedCategories;
            }
            else
            {

                categories = await _categoryRepository.GetCategories(skip, DefaultConst.TakeCount);


                _cache.Set(categoryListCacheKey, categories , TimeSpan.FromSeconds(60));
            }


            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
