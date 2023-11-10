using AutoMapper;
using MediatR;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Requests.Queries;

namespace ShopApi.Application.Features.Category.Handlers.Queries
{


    public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, CategoyDto>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;




        public GetCategoryByIdRequestHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task<CategoyDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);
            return _mapper.Map<CategoyDto>(category);
        }
    }
}
