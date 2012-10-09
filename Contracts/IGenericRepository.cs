using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Objects;

namespace DAL
{
    public interface IGenericRepository<C, T>
        where T : class
        where C : ObjectContext, new()
    {
        C Context { get; }

        IEnumerable<T> GetAll();

        T Single(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}