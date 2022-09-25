using AutoMapper;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>()
        .ForMember(dst => dst.MainFileName,
        opt => opt.MapFrom(src => src.ProductImages.FirstOrDefault().StoredFileName));
    }

}