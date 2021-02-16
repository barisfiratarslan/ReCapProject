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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerServise;

        public CustomersController(ICustomerService customerServise)
        {
            _customerServise = customerServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _customerServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerServise.Add(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerServise.Delete(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerServise.Update(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
    }
}
