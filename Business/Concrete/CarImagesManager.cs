using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [SecuredOperation("carimages.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(CarImage carImages)
        {
            var result = BusinessRules.Run(CheckCountOfCarImages(carImages.CarID));
            if (result != null)
            {
                return result;
            }
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImage carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetByID(int ID)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.ID == ID), Messages.CarImagesListed);
        }

        public IDataResult<List<string>> GetCarImagesByCarID(int carID)
        {
            List<string> list = new List<string>(); 
            var result = _carImagesDal.GetAll(c => c.CarID == carID);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<string>>(new List<string> { @"~CarImages\default.jpg" }, Messages.CarImagesListed);
            }
            foreach (var item in result)
            {
                list.Add(item.ImagePath);
            }
            return new SuccessDataResult<List<string>>(list, Messages.CarImagesListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(CarImage carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        private IResult CheckCountOfCarImages(int carID)
        {
            var result = _carImagesDal.GetAll(c => c.CarID == carID).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImagesCountError);
            }
            return new SuccessResult();
        }
    }
}
