using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Handlers.Queries;
using ShopApi.Application.Features.Category.Requests.Queries;
using ShopApi.Application.Profiles;
using ShopApi.Application.UnitTests.Mocks;
using Shouldly;

namespace ShopApi.Application.UnitTests.Category.Queries
{
    public class GetCategoryListRequestHandlerTests
    {
        IMapper _mapper;
        Mock<IMemoryCache> _mockCash;
        Mock<ICategoryRepository> _mockRepository;

        public GetCategoryListRequestHandlerTests(IMemoryCache memoryCache)
        {
            _mockRepository = MockLeaveRepository.GetCategoryRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();



            // memoryCash
            //var services = new ServiceCollection();
            //services.AddMemoryCache();
            //var serviceProvider = services.BuildServiceProvider();
            //_cash = serviceProvider.GetService<IMemoryCache>();

            _mockCash = new Mock<IMemoryCache>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetCategoryListRequestHandler(_mockRepository.Object, _mapper, _mockCash.Object);

            var result = await handler.Handle(new GetCategoryListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(2);

        }
    }
}
