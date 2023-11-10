using AutoMapper;
using ShopApi.Application.DTOs.Category;
using ShopApi.Domain.Entity;

namespace ShopApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Category Mapping

            CreateMap<Category, ProductDto>().ReverseMap();
            CreateMap<Category, CreateProductDto>().ReverseMap();
            CreateMap<Category, UpdateProductDto>().ReverseMap();

            #endregion



        }
    }
}
