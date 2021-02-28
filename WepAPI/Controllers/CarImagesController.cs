using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _carImagesService.GetByID(ID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarImagesByCarID")]
        public IActionResult GetCarImagesByCarID(int carID)
        {
            var result = _carImagesService.GetCarImagesByCarID(carID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int carID, [FromForm] IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest("Sadece resim dosyası yükleyebilirsiniz");
            }
            CarImage carImages = new CarImage();
            carImages.CarID = carID;
            carImages.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            carImages.Date = DateTime.Now;
            var result = _carImagesService.Add(carImages);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"CarImages\" + carImages.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var data= _carImagesService.GetByID(id);
            var result = _carImagesService.Delete(data.Data);
            if (result.Success)
            {
                System.IO.File.Delete(Path.Combine(@"CarImages\" + data.Data.ImagePath));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] int id, [FromForm] int carID, [FromForm] IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest("Sadece resim dosyası yükleyebilirsiniz");
            }
            var data = _carImagesService.GetByID(id);
            data.Data.CarID = carID;
            System.IO.File.Delete(Path.Combine(@"CarImages\" + data.Data.ImagePath));
            data.Data.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            data.Data.Date = DateTime.Now;
            var result = _carImagesService.Update(data.Data);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"CarImages\" + data.Data.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
