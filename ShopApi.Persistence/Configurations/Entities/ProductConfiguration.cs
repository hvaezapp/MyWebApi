using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.Persistence.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Nokia 1100",
                    FkCategoryId  = 1,
                },
                 new Product
                 {
                     Id = 2,
                     Name = "BMW A",
                     FkCategoryId = 2
                 }
             );
        }
    }
}
