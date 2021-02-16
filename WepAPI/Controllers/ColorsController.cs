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
    public class ColorsController : ControllerBase
    {
        IColorService _colorServise;

        public ColorsController(IColorService colorServise)
        {
            _colorServise = colorServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _colorServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color Color)
        {
            var result = _colorServise.Add(Color);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color Color)
        {
            var result = _colorServise.Delete(Color);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Color Color)
        {
            var result = _colorServise.Update(Color);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
    }
}
