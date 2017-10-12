using GONIS.Core.Interface.EntityFramework;
using GONIS.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace GONIS.Core.Helper.EntityFramework
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>
                                                 where TEntity : Entity
                                                 where TDbContext : DbContext
    {
        private readonly DbContextOptions _options;
        public Repository(DbContextOptions options)
        {
            _options = options ?? throw new ArgumentNullException("options");
        }
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var context = Create())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = Create())
            {
                return context.Set<TEntity>().Where(x=>!x.IsDel)
                              .Where(predicate)
                              .ToList();
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = Create())
            {
                return context.Set<TEntity>()
                              .Where(predicate)
                              .ToList();
            }
        }

        public TEntity GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            using (var context = Create())
            {
                var findEntity = context.Find<TEntity>(id);

                if (findEntity == null)
                    throw new InvalidOperationException($"Entity with id = [{id}], not found");

                return findEntity;
            }
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (entity.Id < 1)
            {
                throw new ArgumentOutOfRangeException("id < 1");
            }

            using (var context = Create())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private TDbContext Create()
        {
            return (TDbContext)Activator.CreateInstance(typeof(TDbContext), new object[] { _options });
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new InvalidOperationException($"entity");
            }
            Update(entity);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id < 1");
            }

            using (var context = Create())
            {
                var removeentity = context.Find<TEntity>(id);
                if (removeentity == null)
                {
                    throw new InvalidOperationException($"entity with id = [{id}], not found");
                }
                Delete(removeentity);
            }
        }


        public void DeleteFromDB(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DeleteFromDB(entity.Id);
        }

        public void DeleteFromDB(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id < 1");
            }
            using (var context = Create())
            {
                var removeentity = context.Find<TEntity>(id);

                if (removeentity == null)
                    throw new InvalidOperationException($"entity with id = [{id}], not found");

                context.Remove(removeentity);
                context.SaveChanges();
            }
        }

    }
}
