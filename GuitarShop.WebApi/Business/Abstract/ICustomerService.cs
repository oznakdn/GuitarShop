using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer>GetAll(Expression<Func<Customer,bool>>Filter=null);
        List<GetAllCustomersModel>GetAllCustomer();
        GetCustomerModel GetCustomer(string firstName,string lastName);
        void AddCustomer(CreateCustomerModel model);
        void UpdateCustomer(UpdateCustomerModel model, string userName);
        void SoftDelete(int id);
    }
}