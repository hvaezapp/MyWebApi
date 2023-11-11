using Moq;
using ShopApi.Application.Contracts.Persistence;



namespace ShopApi.Application.UnitTests.Mocks
{
    public static class MockLeaveRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Domain.Entity.Category>()
            {
                new Domain.Entity.Category
                {
                    Id = 1,
                    Name = "Tv"
                },
                new Domain.Entity.Category
                {
                    Id = 2,
                    Name = "Battery"
                }

            };

            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(categories);

            mockRepo.Setup(r => r.Add(It.IsAny<Domain.Entity.Category>()))
                .ReturnsAsync((Domain.Entity.Category category) =>
                {
                    categories.Add(category);
                    return category;

                });


            return mockRepo;
        }
    }
}
