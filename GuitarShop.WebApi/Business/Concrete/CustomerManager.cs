using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;
using System.Linq;
using AutoMapper;
using GuitarShop.WebApi.Business.ValidationRules.FluentValidation.CustomerValidators;
using FluentValidation;

namespace GuitarShop.WebApi.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo=customerRepo;
            _mapper=mapper;
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> Filter = null)
        {
            return _customerRepo.GetAll();
        }

        public List<GetAllCustomersModel> GetAllCustomer()
        {
           return _customerRepo.GetAllCustomer();
        }

        public GetCustomerModel GetCustomer(string firstName,string lastName)
        {
            var customer=_customerRepo.GetAll(x=>x.FirstName==firstName && x.LastName==lastName).SingleOrDefault();
            if(customer is null) throw new InvalidOperationException("There is no the customer");

            return _mapper.Map<GetCustomerModel>(customer);
            
        }

        public void AddCustomer(CreateCustomerModel model)
        {
            var customer=_customerRepo.GetAll(x=>x.Username==model.Username).FirstOrDefault();
            if(customer is not null) throw new InvalidOperationException("Do not use the username!");

            CreateCustomerValidator validator=new CreateCustomerValidator();
            validator.ValidateAndThrow(model);

            customer=_mapper.Map<Customer>(model);
            _customerRepo.Add(customer);
        }

        public void UpdateCustomer(UpdateCustomerModel model, string userName)
        {
            var customer=_customerRepo.GetBySingle(x=>x.Username==userName);
            if(customer is null) throw new InvalidOperationException("There is no the customer");

            UpdateCustomerValidator validator=new UpdateCustomerValidator();
            validator.ValidateAndThrow(model);

            customer.FirstName=model.FirstName!=default ? model.FirstName : customer.FirstName;
            customer.LastName=model.LastName!=default ? model.LastName : customer.LastName;
            customer.ContactId=model.ContactId!=default ? model.ContactId : customer.ContactId;

            _customerRepo.Update(customer);
        }

        public void SoftDelete(int id)
        {
            var customer=_customerRepo.GetBySingle(x=>x.CustomerID==id);
            if(customer is null) throw new InvalidOperationException("Not found customer for deleting");
            
            _customerRepo.SoftDelete(customer.CustomerID);
        }
    }
}