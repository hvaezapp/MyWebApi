using ShopApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entity
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public int FkCategoryId { get; set; }




        [ForeignKey(nameof(FkCategoryId))]
        public Category Category { get; set; }


    }
}
