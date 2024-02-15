using BilgeCinema.Data.Context;
using BilgeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeCinema.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
      where TEntity : MovieEntity
    {
        private readonly BilgeCinemaContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(BilgeCinemaContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);

            // TODO : First-Single-FirstOrDefault-SingleOfDefault anlatılacak.
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            
            _dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}
