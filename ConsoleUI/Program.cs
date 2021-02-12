using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandID(3))
            {
                Console.WriteLine(car.ToString());
            }
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ToString());
            }
            // TestI();
            // TestII();
        }

        private static void TestI()
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

        private static void TestII()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandID = 3, ColorID = 1, ModelYear = Convert.ToDateTime("2020-01-01"), DailyPrice = 250, Description = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
            carManager.Delete(carManager.GetByID(1004));
            carManager.Update(new Car { ID = 3, BrandID = 3, ColorID = 2, ModelYear = Convert.ToDateTime("2015-01-01"), DailyPrice = 230, Description = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
