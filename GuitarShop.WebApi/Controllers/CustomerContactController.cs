using GuitarShop.WebApi.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerContactController:ControllerBase
    {
        private readonly ICustomerContactService _contactService;
        public CustomerContactController(ICustomerContactService contactService)
        {
            _contactService=contactService;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var result=_contactService.GetAll();
            return Ok(result);
        }
    }
}