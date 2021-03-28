using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetAll(x => x.CarID == rental.CarID && x.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(Messages.RentalFailedAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckDate(Rental rental)
        {
            var result = _rentalDal.GetAll();
            if (result.Where(x => x.CarID == rental.CarID && (rental.RentDate.Ticks <= Convert.ToDateTime(x.ReturnDate).Ticks && rental.RentDate.Ticks >= x.RentDate.Ticks) || (Convert.ToDateTime(rental.ReturnDate).Ticks <= Convert.ToDateTime(x.ReturnDate).Ticks && Convert.ToDateTime(rental.ReturnDate).Ticks >= x.RentDate.Ticks) ||(rental.RentDate.Ticks <= x.RentDate.Ticks && Convert.ToDateTime(rental.ReturnDate).Ticks >= Convert.ToDateTime(x.ReturnDate).Ticks)).Any())
            {
                return new ErrorResult(Messages.RentalFailedAdded);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByID(int ID)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.ID == ID), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int ID)
        {
            if (_rentalDal.GetAll(x => x.CarID == ID && x.ReturnDate == null).Count <= 0)
            {
                return new ErrorResult(Messages.RentalErrorReturn);
            }
            var result = _rentalDal.Get(x => x.ID == ID);
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalReturn);
        }
    }
}
