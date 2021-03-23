using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails();
        List<CarDetailDTO> GetCarDetailsByBrand(int brandID);
        List<CarDetailDTO> GetCarDetailsByColor(int colorID);
        List<CarDetailDTO> GetCarDetailsByColorAndBrand(int colorID, int brandID);
        CarDetailDTO GetCarDetailsByCar(int carID);
    }
}
