using AutoMapper;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.Business.MappingProfiles
{
    public class CustomerMappingProfiles:Profile
    {
        public CustomerMappingProfiles()
        {
            CreateMap<Customer,GetCustomerModel>()
            .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.FirstName))
            .ForMember(dest=>dest.LastName,opt=>opt.MapFrom(src=>src.LastName));


            CreateMap<CreateCustomerModel,Customer>();
        }
    }
}