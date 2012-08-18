using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Objects;
using System.Data;

namespace DAL
{
    public abstract class GenericRepository<T> :
    IGenericRepository<T>
        where T : class
    {
        private readonly ObjectContext _context;
        private readonly IObjectSet<T> _set;

        public GenericRepository(ObjectContext objectContext)
        {
            _context = objectContext;
            _set = _context.CreateObjectSet<T>();
        }

        public ObjectContext Context
        {
            get { return _context; }
        }

        public IObjectSet<T> Set
        {
            get { return _set; }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _set;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
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
    }
}