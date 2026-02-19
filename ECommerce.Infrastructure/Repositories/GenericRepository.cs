using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
           where TEntity : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet; // query على DB مباشرة
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
