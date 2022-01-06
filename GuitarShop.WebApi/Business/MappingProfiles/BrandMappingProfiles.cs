using AutoMapper;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;

namespace GuitarShop.WebApi.Business.MappingProfiles
{
    public class BrandMappingProfiles:Profile
    {
        public BrandMappingProfiles()
        {
            CreateMap<Brand,GetAllBrandsModel>(); //GetAll
            CreateMap<Brand,GetBrandModel>(); //Get
            CreateMap<CreateBrandModel,Brand>(); // Add
            CreateMap<UpdateBrandModel,Brand>(); //Update
        }
    }
}