using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Name.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }            
        }

        public void Delete(Car car)
        {
             _carDal.Delete(car);

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByID(int ID)
        {
            return _carDal.Get(x => x.ID == ID);
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandID(int ID)
        {
            return _carDal.GetAll(x => x.BrandID == ID);
        }

        public List<Car> GetCarsByColorId(int ID)
        {
            return _carDal.GetAll(x => x.ColorID == ID);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
