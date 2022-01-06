using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;

namespace GuitarShop.WebApi.Business.Concrete
{
    public class CustomerContactManager : ICustomerContactService
    {
        private readonly ICustomerContactRepo _contactRepo;
        public CustomerContactManager(ICustomerContactRepo contactRepo)
        {
            _contactRepo=contactRepo;
        }
        public List<CustomerContact> GetAll(Expression<Func<CustomerContact, bool>> Filter = null)
        {
            return _contactRepo.GetAll();
        }
    }
}