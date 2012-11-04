using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data;

namespace DAL
{
    public abstract class GenericRepository<C, T> :
    IGenericRepository<C, T>
        where T : class
        where C : ObjectContext, new()
    {

        #region Member Variables

        private readonly C _context;
        private readonly IObjectSet<T> _set;

        #endregion

        #region Constructor

        public GenericRepository(C objectContext)
        {
            _context = objectContext;
            _set = _context.CreateObjectSet<T>();
        }

        #endregion

        #region IGenericRepository

        public C Context { get { return _context; } }

        public virtual IEnumerable<T> GetAll()
        {
            return _set;
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _set.SingleOrDefault<T>(predicate);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _set.AddObject(entity);
        }

        public virtual void Update(T entity)
        {
            _set.Attach(entity);
            _context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            _set.DeleteObject(entity);
        }

        #endregion

#region Private Methods

        private IEnumerable<TEntity> LoadNavigationFields<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (TEntity entity in entities)
            {
                PerformEagerLoading<TEntity>(entity, this.Context);
            }
            return entities;
        }

        private TEntity LoadNavigationFields<TEntity>(TEntity entity) where TEntity : class
        {
            PerformEagerLoading<TEntity>(entity, this.Context);
            return entity;
        }

        private void PerformEagerLoading<TEntity>(TEntity entity, ObjectContext context) where TEntity : class
        {
            var properties = typeof(TEntity).GetProperties().Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(String) && p.PropertyType != typeof(ObjectChangeTracker));
            foreach (PropertyInfo property in properties)
            {
                context.LoadProperty(entity, property.Name);
            }
        }

        #endregion
    }
}