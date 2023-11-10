using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Product.Requests.Queries;

namespace ShopApi.Application.Features.Product.Handlers.Queries
{


    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;




        public GetProductByIdRequestHandler(IProductRepository productRepository
            , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }



        public async Task<ProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
