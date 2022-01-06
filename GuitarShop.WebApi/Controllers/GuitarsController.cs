using System;
using AutoMapper;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GuitarsController:ControllerBase
    {
        private readonly IGuitarService _guitarService;
        private readonly IMapper _mapper;

        public GuitarsController(IGuitarService guitarService, IMapper mapper)
        {
            _guitarService=guitarService;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAllGuitars()
        {
            var result=_guitarService.GetAllGuitars();
            return Ok(result);
        }

        [HttpGet("GetByCode")]
        public IActionResult GetGuitar(string code)
        {
            var result=_guitarService.GetGuitarByCode(code);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGuitar([FromBody] CreateGuitarModel model)
        {
            try
            {
                _guitarService.AddGuitar(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("Code")]
        public IActionResult UpdateGuitar([FromBody] UpdateGuitarModel model,string code)
        {
            try
            {
                 _guitarService.UpdateGuitar(model,code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGuitar(int GuitarId)
        {

            try
            {
                _guitarService.SoftDelete(GuitarId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();

        }
        
        
    }
}