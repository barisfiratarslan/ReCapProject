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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalServise;

        public RentalsController(IRentalService rentalServise)
        {
            _rentalServise = rentalServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _rentalServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalServise.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("checkdate")]
        public IActionResult CheckDate(Rental rental)
        {
            var result = _rentalServise.CheckDate(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        public IActionResult UpdateReturnDate(int ID)
        {
            var result = _rentalServise.UpdateReturnDate(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalServise.Add(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalServise.Delete(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalServise.Update(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
    }
}
