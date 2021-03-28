using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetByID(int ID);
        IDataResult<List<CreditCard>> GetAll();
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Payment(CreditCard creditCard, decimal price);
    }
}
