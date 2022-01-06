using System.Collections.Generic;
using AutoMapper;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.OrderViewModels;

namespace GuitarShop.WebApi.Business.Concrete
{
    
    public class CustomerOrderManager : ICustomerOrderService
    {
        private readonly ICustomerOrderService _orderService;
        private readonly IMapper _mapper;
        public CustomerOrderManager(ICustomerOrderService orderService, IMapper mapper)
        {
            _orderService=orderService;
            _mapper=mapper;
        }
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        public List<GetAllOrdersModel>GetAlls()
        {
            var orders=_orderService.GetAllOrders();
            List<GetAllOrdersModel>vm=_mapper.Map<List<GetAllOrdersModel>>(orders);
            return vm;
        }
    }
}