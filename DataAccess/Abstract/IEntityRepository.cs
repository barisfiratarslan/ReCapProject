using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
    }
}
