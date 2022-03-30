using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QWERTY.Shared.Db.Infrastructure
{
    public interface IRepository<T> where T : _EntityBase
    {
        _QWERTY_Entities GetContext();
        
        // Marks an entity as new
        void Add(T entity);
        
        T Создать(T? сущность);
        // Marks an entity as modified
        void Обновить(T entity);
        // Marks an entity to be removed
        void Удалить(T entity);
        void Удалить(Expression<Func<T, bool>> where);
        // et an entity by int id
        T GetById(int id);
        // Get an entity using delegate
        /*T Get(Expression<Func<T, bool>> where);*/
        T Найти(Func<T, bool> where);
        bool Exists(Func<T, bool> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        void Коммитнуть();
    }
}
