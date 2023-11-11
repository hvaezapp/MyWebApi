using ShopApi.Application.DTOs.Common;

namespace ShopApi.Application.DTOs.Product
{
    public class UpdateProductDto : BaseDto
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
