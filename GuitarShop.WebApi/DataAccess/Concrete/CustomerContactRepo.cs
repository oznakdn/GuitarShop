using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;

namespace GuitarShop.WebApi.DataAccess.Concrete
{
    public class CustomerContactRepo:RepositoryBase<CustomerContact,GuitarShopDbContext>,ICustomerContactRepo
    {
        
    }
}