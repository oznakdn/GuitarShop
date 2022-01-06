using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GuitarShop.WebApi.Models.Entities;

namespace GuitarShop.WebApi.Business.Abstract
{
    public interface ICustomerContactService
    {
        List<CustomerContact>GetAll(Expression<Func<CustomerContact,bool>>Filter=null);
         
    }
}