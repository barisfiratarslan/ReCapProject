﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetAll(x => x.CarID == rental.CarID && x.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(Messages.RentalFailedAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByID(int ID)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.ID == ID), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int id)
        {
            if (_rentalDal.GetAll(x => x.CarID == id && x.ReturnDate == null).Count <= 0)
            {
                return new ErrorResult(Messages.RentalErrorReturn);
            }
            var result = _rentalDal.Get(x => x.ID == id);
            result.ReturnDate = DateTime.Now.ToString();
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalReturn);
        }
    }
}
