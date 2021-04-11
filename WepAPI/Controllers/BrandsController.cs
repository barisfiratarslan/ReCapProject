using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandServise;

        public BrandsController(IBrandService brandServise)
        {
            _brandServise = brandServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _brandServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandServise.Add(brand);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandServise.Delete(brand);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandServise.Update(brand);
            if (result.Success) { return Ok(result); }
            return BadRequest(result.Message);
        }
    }
}
