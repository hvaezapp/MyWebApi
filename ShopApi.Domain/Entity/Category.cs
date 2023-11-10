using ShopApi.Domain.Common;

namespace ShopApi.Domain.Entity
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
