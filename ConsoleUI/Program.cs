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
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.ToString());
            }
            TestColor();
            TestBrand();
        }

        private static void TestInMemory()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { ID = 6, BrandID = 3, ColorID = 5, ModelYear = new DateTime(2030), DailyPrice = 250, Name = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
            carManager.Delete(carManager.GetByID(6));
            carManager.Update(new Car { ID = 3, BrandID = 3, ColorID = 5, ModelYear = new DateTime(2015), DailyPrice = 230, Name = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void TestCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandID = 3, ColorID = 1, ModelYear = Convert.ToDateTime("2020-01-01"), DailyPrice = 250, Name = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
            carManager.Delete(carManager.GetByID(1004));
            carManager.Update(new Car { ID = 3, BrandID = 3, ColorID = 2, ModelYear = Convert.ToDateTime("2015-01-01"), DailyPrice = 230, Name = "XXX" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ToString());
            }
            foreach (var car in carManager.GetCarsByBrandID(3))
            {
                Console.WriteLine(car.ToString());
            }
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void TestColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Kırmızı" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ToString());
            }
            colorManager.Delete(colorManager.GetByID(3));
            colorManager.Update(new Color { ID = 2, Name = "Lacivert" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ToString());
            }
        }

        private static void TestBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Ferrari" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.ToString());
            }
            brandManager.Delete(brandManager.GetByID(3));
            brandManager.Update(new Brand { ID = 2, Name = "Renault" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.ToString());
            }
        }
    }
}
