using ShopApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entity
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
