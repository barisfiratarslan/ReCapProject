using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ID=1, BrandID=1, ColorID=1, ModelYear=new DateTime(2000), DailyPrice=200, Name="BMW"},
                new Car{ID=2, BrandID=1, ColorID=2, ModelYear=new DateTime(2010), DailyPrice=80, Name="Toyota"},
                new Car{ID=3, BrandID=2, ColorID=3, ModelYear=new DateTime(2020), DailyPrice=600, Name="Mercedes"},
                new Car{ID=4, BrandID=2, ColorID=3, ModelYear=new DateTime(2005), DailyPrice=60, Name="Fiat"},
                new Car{ID=5, BrandID=3, ColorID=4, ModelYear=new DateTime(2003), DailyPrice=100, Name="Ferrari"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c => c.ID == car.ID);
            _cars.Remove(deletedCar);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.ID == car.ID);
            updatedCar.BrandID = car.BrandID;
            updatedCar.ColorID = car.ColorID;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Name = car.Name;
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetailsByBrand(int brandID)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetailsByColor(int colorID)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetailsByColorAndBrand(int colorID, int brandID)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetailsByCar(int carID)
        {
            throw new NotImplementedException();
        }

        CarDetailDTO ICarDal.GetCarDetailsByCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
