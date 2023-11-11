using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Product.Requests.Queries;
using ShopApi.Domain.Entity;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Features.Product.Handlers.Queries
{


    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {

        private const string productListCacheKey = "productList";

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;




        public GetProductListRequestHandler(IProductRepository productRepository
            , IMapper mapper , IMemoryCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            // paging
            int skip = (request.PageNom - 1) * 10;

          
            if (_cache.TryGetValue(productListCacheKey, out List<Domain.Entity.Product> products))
            {
                
            }
            else
            {
              
                products = await _productRepository.GetProducts(skip, DefaultConst.TakeCount);

                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                //        .SetPriority(CacheItemPriority.Normal)
                //        .SetSize(1024);


                _cache.Set(productListCacheKey, products , TimeSpan.FromSeconds(60));
            }


            //var products = await _productRepository.GetProducts(request.FilterByName , skip  , DefaultConst.TakeCount);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
