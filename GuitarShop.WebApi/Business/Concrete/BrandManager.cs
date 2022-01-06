using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;
using System.Linq;
using GuitarShop.WebApi.Business.ValidationRules.FluentValidation.BrandValidators;
using FluentValidation;

namespace GuitarShop.WebApi.Business.Concrete
{
    public class BrandManager : IBrandService
    {

        private readonly IBrandRepo _brandRepo;
        private readonly IMapper _mapper;

        public BrandManager(IBrandRepo brandRepo, IMapper mapper)
        {
            _brandRepo=brandRepo;
            _mapper=mapper;
        }
        
        
        public Brand Add(Brand entity)
        {
            return _brandRepo.Add(entity);
        }

        public void Delete(int id)
        {
            _brandRepo.Delete(id);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> Filter = null)
        {
            return _brandRepo.GetAll(Filter);
        }

        public Brand GetBySingle(Expression<Func<Brand, bool>> Filter)
        {
            return _brandRepo.GetBySingle(Filter);
        }

        public Brand Update(Brand entity)
        {
            return _brandRepo.Update(entity);
        }


        public List<GetAllBrandsModel> GetAllBrands()
        {
            var brand=_brandRepo.GetAll();
            List<GetAllBrandsModel> vm=_mapper.Map<List<GetAllBrandsModel>>(brand);
            return vm;
        }

        public GetBrandModel GetBrandByName(string brandName)
        {
            var brand=_brandRepo.GetAll(x=>x.BrandName==brandName).SingleOrDefault();
            if(brand is null) throw new InvalidOperationException("There is no the brand");

            GetBrandModel model=_mapper.Map<GetBrandModel>(brand);
            return model;
        }

        public void CreateBrand(CreateBrandModel model)
        {
            var brand=_brandRepo.GetBySingle(x=>x.BrandName==model.BrandName);
            if(brand is not null) throw new InvalidOperationException("There is already the brand");

            CreateBrandValidator validator=new CreateBrandValidator();
            validator.ValidateAndThrow(model);

            brand=_mapper.Map<Brand>(model);
            _brandRepo.Add(brand);
        }

        public void UpdateBrand(UpdateBrandModel model, string brandName)
        {
            
            var brand=_brandRepo.GetBySingle(x=>x.BrandName==brandName);
            if(brand is null) throw new InvalidOperationException("There is no the brand");

            UpdateBrandValidator validator=new UpdateBrandValidator();
            validator.ValidateAndThrow(model);

            brand.BrandName=model.BrandName!=default ? model.BrandName : brand.BrandName;
            brand.Description=model.Description!=default ? model.Description : brand.Description;

            _brandRepo.Update(brand);
        
        }

        public void DeleteBrand(string brandName)
        {
            var brand=_brandRepo.GetBySingle(x=>x.BrandName==brandName);
            if(brand is null) throw new InvalidOperationException("There is no the brand for deleting");

            var Id=brand.BrandID;
            _brandRepo.Delete(Id);
        }
    }
}