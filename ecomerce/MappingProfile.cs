using ecomerce.Dtos;
using ecomerce.Model;
using AutoMapper;

 namespace ecomerce
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblProduct, TblProductDto>()
                //.ForMember(dest => dest.VendorName, src => src.MapFrom(src => src.VendorId))
                //.ForMember(dest => dest.IsFree, src => src.MapFrom(src => src.Price == 0))
                .ReverseMap();
            CreateMap<TblCategory, TblCategoryDto>()
                .ReverseMap();

        }
    }
}