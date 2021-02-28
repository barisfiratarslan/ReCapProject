using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<CarImage> GetByID(int ID);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<string>> GetCarImagesByCarID(int carID);
        IResult Add(CarImage carImages);
        IResult Update(CarImage carImages);
        IResult Delete(CarImage carImages);
    }
}
