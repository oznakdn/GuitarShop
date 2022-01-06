using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Business.Concrete;
using GuitarShop.WebApi.DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController:ControllerBase
    {
        private readonly ICustomerOrderService _orderService;
        public OrdersController(ICustomerOrderService orderService)
        {
            _orderService=orderService;
        }
    

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var result=_orderService.GetAlls();
            return Ok(result);
        }
    }
}