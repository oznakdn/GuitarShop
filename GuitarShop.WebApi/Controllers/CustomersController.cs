using System;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController:ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomersController(ICustomerService customerService)
        {
            _customerService=customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var result=_customerService.GetAllCustomer();
            return Ok(result);
        }

        [HttpGet("FullName")]
        public IActionResult GetCustomer(string FirstName,string LastName)
        {
            GetCustomerModel result;
            try
            {
                result=_customerService.GetCustomer(FirstName,LastName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer(CreateCustomerModel model)
        {
            try
            {
                 _customerService.AddCustomer(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerModel model, string Username)
        {
            try
            {
                 _customerService.UpdateCustomer(model,Username);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCustomer(int Id)
        {
            
            try
            {
                 _customerService.SoftDelete(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}