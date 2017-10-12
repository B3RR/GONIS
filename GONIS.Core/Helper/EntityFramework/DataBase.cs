using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GONIS.Core.Model.Security;

namespace GONIS.Core.Helper.EntityFramework
{
    public class DataBase : DbContext
    {
        public DbSet<Role> Roles { get; }
        public DbSet<User> Users { get; }
        public DbSet<RolesUsers> RolesUsers { get; }

        public DataBase(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = new FluentAPI.Security.Roles();
            roles.OnModelCreating(modelBuilder);

            var users = new FluentAPI.Security.Users();
            users.OnModelCreating(modelBuilder);

            var rolesUsers = new FluentAPI.Security.RolesUsers();
            rolesUsers.OnModelCreating(modelBuilder);

        }
    }
}
