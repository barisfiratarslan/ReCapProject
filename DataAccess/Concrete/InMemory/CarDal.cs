using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class CarDal : ICarDal
    {
        List<Car> _cars;

        public CarDal()
        {
            _cars = new List<Car>
            {
                new Car{ID=1, BrandID=1, ColorID=1, ModelYear=new DateTime(2000), DailyPrice=200, Description="BMW"},
                new Car{ID=2, BrandID=1, ColorID=2, ModelYear=new DateTime(2010), DailyPrice=80, Description="Toyota"},
                new Car{ID=3, BrandID=2, ColorID=3, ModelYear=new DateTime(2020), DailyPrice=600, Description="Mercedes"},
                new Car{ID=4, BrandID=2, ColorID=3, ModelYear=new DateTime(2005), DailyPrice=60, Description="Fiat"},
                new Car{ID=5, BrandID=3, ColorID=4, ModelYear=new DateTime(2003), DailyPrice=100, Description="Ferrari"},
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

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetByID(int carID)
        {
            return _cars.SingleOrDefault(c => c.ID == carID);
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.ID == car.ID);
            updatedCar.BrandID = car.BrandID;
            updatedCar.ColorID = car.ColorID;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
        }
    }
}
