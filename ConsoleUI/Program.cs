using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { ID = 6, BrandID = 3, ColorID = 5, ModelYear = new DateTime(2030), DailyPrice = 250, Description = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
            carManager.Delete(carManager.GetByID(6));
            carManager.Update(new Car { ID = 3, BrandID = 3, ColorID = 5, ModelYear = new DateTime(2015), DailyPrice = 230, Description = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
