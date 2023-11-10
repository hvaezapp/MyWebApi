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

            CreateMap<Category, CategoyDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            #endregion



        }
    }
}
