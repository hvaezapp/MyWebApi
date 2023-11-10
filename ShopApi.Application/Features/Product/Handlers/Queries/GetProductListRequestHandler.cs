using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Product.Requests.Queries;
using ShopApi.Infrastructure.AppUtility;

namespace ShopApi.Application.Features.Product.Handlers.Queries
{


    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;




        public GetProductListRequestHandler(IProductRepository productRepository
            , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }



        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            int skip = (request.PageNom * 10) - 1;

            var products = await _productRepository.GetProducts(request.FilterByName , skip  , DefaultConst.TakeCount);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
