﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using(ReCapContext context=new ReCapContext())
            {
                var result = from car in context.Car
                             join color in context.Color
                             on car.ColorID equals color.ID
                             join brand in context.Brand
                             on car.BrandID equals brand.ID
                             select new CarDetailDTO { BrandName = brand.Name, CarName = car.Name, ColorName = color.Name, DailyPrice = car.DailyPrice };
                return result.ToList();
            }
        }
    }
}