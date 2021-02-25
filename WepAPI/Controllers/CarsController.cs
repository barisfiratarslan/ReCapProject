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
    public class CarsController : ControllerBase
    {
        //IResult Add(Car car);
        //IResult Update(Car car);
        //IResult Delete(Car car);
        //IDataResult<List<CarDetailDTO>> GetCarDetails();
        ICarService _carServise;

        public CarsController(ICarService carServise)
        {
            _carServise = carServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _carServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorID(int ID)
        {
            var result = _carServise.GetCarsByColorID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandID(int ID)
        {
            var result = _carServise.GetCarsByBrandID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carServise.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carServise.Add(car);
            if (result.Success) 
            { 
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carServise.Delete(car);
            if (result.Success) 
            { 
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carServise.Update(car);
            if (result.Success) 
            { 
                return Ok(result); 
            }
            return BadRequest();
        }
    }
}
