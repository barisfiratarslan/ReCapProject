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
    public class UsersController : ControllerBase
    {
        IUserService _userServise;

        public UsersController(IUserService userServise)
        {
            _userServise = userServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _userServise.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userServise.Add(user);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userServise.Delete(user);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userServise.Update(user);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
    }
}
