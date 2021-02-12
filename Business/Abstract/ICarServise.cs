using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarServise
    {
        List<Car> GetCarsByBrandID(int ID);
        List<Car> GetCarsByColorId(int ID);
        Car GetByID(int ID);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
