using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car t)
        {
            using(ReCapContext context=new ReCapContext())
            {
                var addedCar = context.Entry(t);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car t)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedCar = context.Entry(t);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car t)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedCar = context.Entry(t);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
