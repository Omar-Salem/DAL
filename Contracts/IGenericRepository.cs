using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Objects;

namespace DAL
{
    public interface IGenericRepository<T> where T : class
    {
        ObjectContext Context { get; }

        IEnumerable<T> GetAll();

        T Single(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}