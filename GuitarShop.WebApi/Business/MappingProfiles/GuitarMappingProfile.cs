using AutoMapper;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.Enums;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;

namespace GuitarShop.WebApi.Business.MappingProfiles
{
    public class GuitarMappingProfile:Profile
    {
        public GuitarMappingProfile()
        {
            CreateMap<Guitar,GetAllGuitarsModel>()
            .ForMember(dest=>dest.GuitarType,opt=>opt.MapFrom(src=>((GuitarTypeEnum)src.GuitarType).ToString()))
            .ForMember(dest=>dest.Brand,opt=>opt.MapFrom(src=>src.Brand.BrandName))
            .ForMember(dest=>dest.Code,opt=>opt.MapFrom(src=>src.Code))
            .ForMember(dest=>dest.Features,opt=>opt.MapFrom(src=>src.Features))
            .ForMember(dest=>dest.Model,opt=>opt.MapFrom(src=>src.Model))
            .ForMember(dest=>dest.Price,opt=>opt.MapFrom(src=>src.Price))
            .ForMember(dest=>dest.Photo,opt=>opt.MapFrom(src=>src.Photo));

            CreateMap<Guitar,GetGuitarModel>()
            .ForMember(dest=>dest.GuitarType,opt=>opt.MapFrom(src=>((GuitarTypeEnum)src.GuitarType).ToString()))
            .ForMember(dest=>dest.Brand,opt=>opt.MapFrom(src=>src.Brand.BrandName))
            .ForMember(dest=>dest.Code,opt=>opt.MapFrom(src=>src.Code))
            .ForMember(dest=>dest.Features,opt=>opt.MapFrom(src=>src.Features))
            .ForMember(dest=>dest.Model,opt=>opt.MapFrom(src=>src.Model))
            .ForMember(dest=>dest.Price,opt=>opt.MapFrom(src=>src.Price))
            .ForMember(dest=>dest.Photo,opt=>opt.MapFrom(src=>src.Photo));

            CreateMap<CreateGuitarModel,Guitar>();
            



            
        }
    }
}