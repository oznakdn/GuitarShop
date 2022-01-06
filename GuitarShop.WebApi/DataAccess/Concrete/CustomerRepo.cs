using System.Collections.Generic;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.DataAccess.Concrete
{
    public class CustomerRepo:RepositoryBase<Customer,GuitarShopDbContext>,ICustomerRepo
    {
        public List<GetAllCustomersModel>GetAllCustomer()
        {
            using (var context=new GuitarShopDbContext())
            {

                 var customers=(from cust in context.Customers.Where(x=>x.IsActive==true)
                               join cont in context.customerContacts
                               on cust.ContactId equals cont.ContactID
                               select new GetAllCustomersModel
                               {
                                  FirstName=cust.FirstName,
                                  LastName=cust.LastName,
                                  Contact=$"Email:{cont.Email} Phone:{cont.Phone} Address:{cont.Address} City:{cont.City} Country:{cont.Country}"
                               }).ToList();

                    return customers;
                
                
            }
        }

        public void SoftDelete(int id)
        {
            using (var context=new GuitarShopDbContext())
            {
                 var customer=context.Customers.Where(x=>x.CustomerID==id).SingleOrDefault();
                 customer.IsActive=false;
                 context.SaveChanges();
            }
        }
    }
}