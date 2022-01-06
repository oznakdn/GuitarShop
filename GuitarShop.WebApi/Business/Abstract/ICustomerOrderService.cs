using System.Collections.Generic;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.OrderViewModels;

namespace GuitarShop.WebApi.Business.Abstract
{
    public interface ICustomerOrderService
    {
        List<Order>GetAllOrders();
        List<GetAllOrdersModel>GetAlls();
         
    }
}