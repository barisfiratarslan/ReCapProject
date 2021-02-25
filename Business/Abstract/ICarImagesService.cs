using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<CarImages> GetByID(int ID);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<string>> GetCarImagesByCarID(int carID);
        IResult Add(CarImages carImages);
        IResult Update(CarImages carImages);
        IResult Delete(CarImages carImages);
    }
}
