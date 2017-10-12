using GONIS.Core.Interface.EntityFramework;
using GONIS.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GONIS.Core.Helper.EntityFramework
{
    public class Transaction<TEntity> : IRepository<TEntity>
                                           where TEntity : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Transaction(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _dbSet = _context.Set<TEntity>();
        }

        public event Action<TEntity> BeforeAdded;
        public event Action<TEntity> BeforeUpdated;
        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            BeforeAdded?.Invoke(entity);

            entity.WhenCreated = DateTime.Now;
            entity.IsDel = false;

            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (entity.Id < 1)
                throw new ArgumentOutOfRangeException("id < 1");

            BeforeUpdated?.Invoke(entity);

            entity.WhenUpdated = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id");

            var findEntity = _dbSet.Find(id);

            if (findEntity == null)
                throw new InvalidOperationException($"Entity with id = [{id}], not found");

            return findEntity;
        }
        public IEnumerable<TEntity> GetAll (Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(x=>!x.IsDel).Where(predicate).ToList();
        }


        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (entity.Id < 1)
                throw new ArgumentOutOfRangeException("id < 1");

            BeforeUpdated?.Invoke(entity);

            entity.WhenUpdated = DateTime.Now;
            entity.IsDel = true;

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
             Delete(GetById(id));
        }


        public void DeleteFromDB(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (entity.Id < 1)
                throw new ArgumentOutOfRangeException("id < 1");
            DeleteFromDB(entity.Id);
        }

        public void DeleteFromDB(int id)
        {
            _dbSet.Remove(GetById(id));
        }

    }
}