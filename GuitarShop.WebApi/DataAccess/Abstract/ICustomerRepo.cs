using System.Collections.Generic;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.DataAccess.Abstract
{
    public interface ICustomerRepo:IRepository<Customer>
    {
         List<GetAllCustomersModel>GetAllCustomer();
         void SoftDelete(int id);
    }
}