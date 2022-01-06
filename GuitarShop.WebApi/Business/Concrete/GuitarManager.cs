using System.Collections.Generic;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;
using System.Linq;
using GuitarShop.WebApi.Models.Entities;
using AutoMapper;
using System;
using GuitarShop.WebApi.Business.ValidationRules.FluentValidation.GuitarValidators;
using FluentValidation;

namespace GuitarShop.WebApi.Business.Concrete
{
    public class GuitarManager : IGuitarService
    {

        private readonly IGuitarRepo _guitarRepo;
        private readonly IMapper _mapper;
        public GuitarManager(IGuitarRepo guitarRepo, IMapper mapper)
        {
            _guitarRepo=guitarRepo;
            _mapper=mapper;
        }

        public Guitar Add(Guitar entity)
        {
            return _guitarRepo.Add(entity);
        }

        public List<GetAllGuitarsModel> GetAllGuitars()
        {
            var guitar=_guitarRepo.GetAllGuitarsModel();
            
            List<GetAllGuitarsModel>vm=_mapper.Map<List<GetAllGuitarsModel>>(guitar);
            return vm;
        }

        public List<Guitar> GetAllGuitarsModel()
        {
            return _guitarRepo.GetAllGuitarsModel();
        }

        public Guitar GetGuitar(string code)
        {
            return _guitarRepo.GetGuitar(code);
        }

        public void SoftDelete(int id)
        {
            var guitar=_guitarRepo.GetAll(x=>x.GuitarID==id).SingleOrDefault();
            if(guitar is null) throw new InvalidOperationException("There is no the guitar");

            
            _guitarRepo.SoftDelete(id);
        }

        public Guitar Update(Guitar entity)
        {
            return _guitarRepo.Update(entity);
        }

        public GetGuitarModel GetGuitarByCode(string code)
        {
            var guitar=_guitarRepo.GetGuitar(code);
            GetGuitarModel model=_mapper.Map<GetGuitarModel>(guitar);
            return model;
        }

        public void AddGuitar(CreateGuitarModel model)
        {
            var guitar=_guitarRepo.GetAll(x=>x.Code==model.Code).SingleOrDefault();
            if(guitar is not null) throw new InvalidOperationException("There is already the guitar");

            CreateGuitarValidator validator=new CreateGuitarValidator();
            validator.ValidateAndThrow(model);

            guitar=_mapper.Map<Guitar>(model);
           _guitarRepo.Add(guitar);
            
        }

        public void UpdateGuitar(UpdateGuitarModel model,string code)
        {
            var guitar=_guitarRepo.GetAll(x=>x.Code==code).SingleOrDefault();
            if(guitar is null) throw new InvalidOperationException("There is no the guitar");
            
            UpdateGuitarValidator validator=new UpdateGuitarValidator();
            validator.ValidateAndThrow(model);

            guitar.BrandId=model.BrandId!=default ? model.BrandId : guitar.BrandId;
            guitar.Model=model.Model!!=default ? model.Model : guitar.Model;
            guitar.Code=model.Code!=default ? model.Code : guitar.Code;
            guitar.Features=model.Features!=default ? model.Features : guitar.Features;
            guitar.Price=model.Price!=default ? model.Price : guitar.Price;
            guitar.Photo=model.Photo!=default ? model.Photo : guitar.Photo;
            guitar.IsActive=model.IsActive!=default ? model.IsActive : guitar.IsActive;
            guitar.IsStock=model.IsStock!=default ? model.IsStock : guitar.IsStock;

            _guitarRepo.Update(guitar);

        }
    }
}