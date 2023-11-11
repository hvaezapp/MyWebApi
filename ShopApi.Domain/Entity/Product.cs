using ShopApi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Domain.Entity
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }




        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }


    }
}
