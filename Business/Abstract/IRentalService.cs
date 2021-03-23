using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetByID(int ID);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult UpdateReturnDate(int ID);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
