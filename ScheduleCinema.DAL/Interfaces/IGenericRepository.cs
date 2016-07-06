using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScheduleCinema.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
