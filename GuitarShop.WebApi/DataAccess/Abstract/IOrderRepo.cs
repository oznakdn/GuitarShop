using System.Collections.Generic;
using GuitarShop.WebApi.Models.Entities;

namespace GuitarShop.WebApi.DataAccess.Abstract
{
    public interface IOrderRepo:IRepository<Order>
    {
        List<Order>GetAllOrders();
    }
}