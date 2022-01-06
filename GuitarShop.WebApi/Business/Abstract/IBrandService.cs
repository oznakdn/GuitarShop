using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;

namespace GuitarShop.WebApi.Business.Abstract
{
    public interface IBrandService
    {
        Brand Add(Brand entity);
        Brand Update (Brand entity);
        void Delete(int id);
        List<Brand>GetAll(Expression<Func<Brand,bool>>Filter=null);
        Brand GetBySingle(Expression<Func<Brand,bool>>Filter);


        List<GetAllBrandsModel> GetAllBrands();
        GetBrandModel GetBrandByName(string brandName);
        void CreateBrand(CreateBrandModel model);
        void UpdateBrand(UpdateBrandModel model, string brandName);
        void DeleteBrand(string brandName);
    }
}