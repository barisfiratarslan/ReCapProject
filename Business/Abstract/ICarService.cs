using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandID(int ID);
        IDataResult<List<Car>> GetCarsByColorID(int ID);
        IDataResult<Car> GetByID(int ID);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<List<CarDetailDTO>> GetCarDetailsByBrand(int brandID);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColor(int colorID);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColorAndBrand(int colorID, int brandID);
        IDataResult<CarDetailDTO> GetCarDetailsByCar(int carID);
    }
}
