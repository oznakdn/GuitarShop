using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;

namespace GuitarShop.WebApi.DataAccess.Concrete
{
    public class BrandRepo:RepositoryBase<Brand,GuitarShopDbContext>,IBrandRepo
    {
        
    }
}