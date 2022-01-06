using AutoMapper;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.Enums;
using GuitarShop.WebApi.Models.ViewModels.OrderViewModels;

namespace GuitarShop.WebApi.Business.MappingProfiles
{
    public class OrderMappingProfiles:Profile
    {
        public OrderMappingProfiles()
        {
            CreateMap<Order,GetAllOrdersModel>()
            .ForMember(dest=>dest.Guitar,opt=>opt.MapFrom(src=>src.Guitar.Brand.BrandName+" "+src.Guitar.Code))
            .ForMember(dest=>dest.Customer,opt=>opt.MapFrom(src=>src.Customer.FirstName+" "+src.Customer.LastName))
            .ForMember(dest=>dest.BuyDate,opt=>opt.MapFrom(src=>src.BuyDate.Date.ToString("dd,MM,yyyy")))
            .ForMember(dest=>dest.Amount,opt=>opt.MapFrom(src=>src.Amount))
            .ForMember(dest=>dest.PayType,opt=>opt.MapFrom(src=>((PayTypeEnum)src.PayType).ToString()));

        }
    }
}