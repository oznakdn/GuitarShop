using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;
using System.Linq;
using System.Collections.Generic;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;
using GuitarShop.WebApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.WebApi.DataAccess.Concrete
{
    public class GuitarRepo : RepositoryBase<Guitar, GuitarShopDbContext>,IGuitarRepo
    {
        public void SoftDelete(int id)
        {
            using (var context=new GuitarShopDbContext())
            {
                 var deleted=context.Guitars.Find(id);
                 deleted.IsActive=false;
                 context.SaveChanges();
            }
        }

        public List<GetAllGuitarsModel>GetAllGuitars()
        {
            using (var context=new GuitarShopDbContext())
            {
                 var guitars=from g in context.Guitars
                             select new GetAllGuitarsModel
                             {
                                GuitarType=((GuitarTypeEnum)g.GuitarType).ToString(),
                                Brand=g.Brand.BrandName,
                                Model=g.Model,
                                Code=g.Code,
                                Features=g.Features,
                                Price=g.Price,
                                Photo=g.Photo
                             };
                    return guitars.ToList();
            }
        }

        public List<Guitar>GetAllGuitarsModel()
        {
            using (var context=new GuitarShopDbContext())
            {
                 return context.Guitars.Where(x=>x.IsActive==true).Include(x=>x.Brand).ToList();
        
            }
        }

        public Guitar GetGuitar(string code)
        {
            using (var context=new GuitarShopDbContext())
            {
                var guitar= context.Guitars.Where(x=>x.Code==code).Include(x=>x.Brand).SingleOrDefault();
                return guitar;
            }
        }

        
    }
}