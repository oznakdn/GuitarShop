using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GuitarShop.WebApi.DataAccess.Concrete
{
    public class OrderRepo:RepositoryBase<Order,GuitarShopDbContext>,IOrderRepo
    {
        public List<Order>GetAllOrders()
        {
            using (var context=new GuitarShopDbContext())
            {
                 var orders=context.Orders.Include(x=>x.Guitar).Include(x=>x.Customer).ToList();
                 return orders;
            }
        }
    }
}