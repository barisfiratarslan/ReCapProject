using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Car
                             on rental.CarID equals car.ID
                             join color in context.Color
                             on car.ColorID equals color.ID
                             join brand in context.Brand
                             on car.BrandID equals brand.ID                             
                             join customer in context.Customers
                             on rental.CustomerID equals customer.ID
                             join user in context.Users
                             on customer.ID equals user.ID
                             select new RentalDetailDto { ID = rental.ID, BrandName = brand.Name, CarName = car.Name, ColorName = color.Name, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate, Musteri = user.FirstName + " " + user.LastName };
                return result.ToList();
            }
        }
    }
}
