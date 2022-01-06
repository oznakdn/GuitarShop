using System;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController:ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService=brandService;
        }

        [HttpGet("GetAllBrandsWithId")]
        public IActionResult GetAllBrandsWithId()
        {
            var result=_brandService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var result=_brandService.GetAllBrands();
            return Ok(result);
        }

        [HttpGet("BrandName")]
        public IActionResult GetBrand(string brandName)
        {
            GetBrandModel result;
            try
            {
                result=_brandService.GetBrandByName(brandName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBrand([FromBody] CreateBrandModel model)
        {
            try
            {
                 _brandService.CreateBrand(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBrand([FromBody] UpdateBrandModel model, string brandName)
        {
            try
            {
                 _brandService.UpdateBrand(model,brandName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("BrandName")]
        public IActionResult DeleteBrand(string BrandName)
        {
            try
            {
                 _brandService.DeleteBrand(BrandName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}