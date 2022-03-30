using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace QWERTY.Shared.Db.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private _QWERTY_Entities _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory {
            get;
            private set;
        }

        protected _QWERTY_Entities DbContext
        {
            get { return _dataContext ?? (_dataContext = DbFactory.Init()); }
        }
        #endregion
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="dbFactory"></param>
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }
        
        #region Implementation

        public virtual _QWERTY_Entities GetContext() => DbContext;
        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual T Создать(T сущность) => _dbSet.Add(сущность);

        public virtual void Обновить(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Удалить(T entity) => _dbSet.Remove(entity);

        public virtual void Удалить(Expression<Func<T, bool>> where)
        {
            foreach (var obj in _dbSet.Where(where))
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual T GetById(int id) => _dbSet.Find(id);

        public virtual IEnumerable<T> GetAll() => GetMany(r => true);

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) 
            => 
                _dbSet.Where(@where);

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
        public T? Найти(Func<T, bool> where) => _dbSet.FirstOrDefault(@where);
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".

        public bool Exists(Func<T, bool> where) => _dbSet.Where(@where).Any();

        public void Коммитнуть() => DbContext.Commit();

        

        #endregion
    }
}
