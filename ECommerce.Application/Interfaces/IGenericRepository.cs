using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }

}
