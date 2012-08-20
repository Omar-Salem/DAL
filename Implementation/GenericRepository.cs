using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data;

namespace DAL
{
    public abstract class GenericRepository<T> :
    IGenericRepository<T>
        where T : class
    {

        #region Member Variables

        private readonly ObjectContext _context;
        private readonly IObjectSet<T> _set; 

        #endregion

        #region Constructor

        public GenericRepository(ObjectContext objectContext)
        {
            _context = objectContext;
            _set = _context.CreateObjectSet<T>();
        } 

        #endregion

        #region IGenericRepository

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
    }
}