using GONIS.Core.Interface.EntityFramework;
using GONIS.Core.Model;
using GONIS.Core.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Helper.EntityFramework
{
    public class DataContext : IDataContext
    {
        private DataBase _dbContext;

        public IRepository<Role> Roles { get; }
        public IRepository<User> Users { get; }
        public IRepository<RolesUsers> RolesUsers { get; }

        public DataContext(DbContextOptions options)
        {
            _dbContext = new DataBase(options);

            Roles = CreateRepository<Role>();
            Users = CreateRepository<User>();
            RolesUsers = CreateRepository<RolesUsers>();

        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private IRepository<TEntity> CreateRepository<TEntity>() where TEntity : Entity
        {
            var repo = new Transaction<TEntity>(_dbContext);

            repo.BeforeAdded += BeforeAdded;
            repo.BeforeUpdated += BeforeUpdated;

            return repo;
        }

        private void BeforeAdded(Entity entity)
        {
            entity.WhenCreated = DateTime.Now;
            //entity.WhoCreated = "";
 
        }
        private void BeforeUpdated(Entity entity)
        {
            entity.WhenUpdated= DateTime.Now;
            //entity.WhoUpdated = "";

        }
    }
}
