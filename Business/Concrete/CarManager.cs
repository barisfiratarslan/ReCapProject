using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarServise
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarFailedAddOrUpdate);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
             _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetByID(int ID)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.ID == ID), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandID(int ID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandID == ID), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorID == ID), Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            if (car.Name.Length < 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarFailedAddOrUpdate);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
