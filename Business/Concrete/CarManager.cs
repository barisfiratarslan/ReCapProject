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
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        [CacheRemoveAspect("ICarService.Get")]
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

        public IDataResult<List<CarDetailDTO>> GetCarDetailsByBrand(int brandID)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsByBrand(brandID), Messages.CarListed);
        }

        public IDataResult<CarDetailDTO> GetCarDetailsByCar(int carID)
        {
            return new SuccessDataResult<CarDetailDTO>(_carDal.GetCarDetailsByCar(carID), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailsByColor(int colorID)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsByColor(colorID), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailsByColorAndBrand(int colorID, int brandID)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsByColorAndBrand(colorID, brandID), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandID(int ID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandID == ID), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorID(int ID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorID == ID), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
