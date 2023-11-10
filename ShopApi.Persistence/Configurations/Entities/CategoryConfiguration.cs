using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.Persistence.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Mobile",
                },
                 new Category
                 { 
                     Id = 2 , 
                     Name = "Vehicle",
                 }
             );
        }
    }
}
