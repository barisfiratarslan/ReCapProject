using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Payment(CreditCard creditCard, decimal price)
        {
            var result = _creditCardDal.Get(x => x.CardNumber.Equals(creditCard.CardNumber) && x.Name.Equals(creditCard.Name) && x.LastUsingMonth == creditCard.LastUsingMonth && x.LastUsingYear == creditCard.LastUsingYear && x.CVV == creditCard.CVV);
            if (result != null)
            {
                if (result.Balance >= price)
                {
                    result.Balance = result.Balance - price;                    
                    _creditCardDal.Update(result);
                    return new SuccessResult(Messages.CreditCarPayment + ", Kalan bakiyeniz: " +result.Balance);
                }
                else
                {
                    return new ErrorResult(Messages.CreditCardBalancaError);
                }
            }
            else
            {
                return new ErrorResult(Messages.CreditCardInfoError);
            }
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.CreditCardListed);
        }

        public IDataResult<CreditCard> GetByID(int ID)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(x => x.ID == ID), Messages.CreditCardListed);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
