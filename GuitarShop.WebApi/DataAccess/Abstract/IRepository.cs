using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GuitarShop.WebApi.DataAccess.Abstract
{
    public interface IRepository<T> where T:class,new()
    {
        T Add(T entity);
        T Update (T entity);
        void Delete(int id);
        List<T>GetAll(Expression<Func<T,bool>>Filter=null);
        T GetBySingle(Expression<Func<T,bool>>Filter);

    }
}