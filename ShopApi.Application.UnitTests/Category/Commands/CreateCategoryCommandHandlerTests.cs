using AutoMapper;
using Moq;
using ShopApi.Application.Contracts.Persistence;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Handlers.Commands;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Profiles;
using ShopApi.Application.Responses;
using ShopApi.Application.UnitTests.Mocks;
using Shouldly;

namespace ShopApi.Application.UnitTests.Category.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ICategoryRepository> _mockRepository;
        CreateCategoryDto _categoryDto;
        public CreateCategoryCommandHandlerTests()
        {
            _mockRepository = MockLeaveRepository.GetCategoryRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _categoryDto = new CreateCategoryDto()
            {
                Name = "Test DTO"
            };
        }


        [Fact]
        public async Task CreateCategory()
        {
            var handler = new CreateCategoryCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateCategoryCommand()
            {
                CreateCategoryDto = _categoryDto

            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            var categories = await _mockRepository.Object.GetAll();

            categories.Count.ShouldBe(3);
        }


    }
}
