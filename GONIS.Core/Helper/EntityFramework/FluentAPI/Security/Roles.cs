using GONIS.Core.Interface.EntityFramework;
using GONIS.Core.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Helper.EntityFramework.FluentAPI.Security
{
    public class Roles
    {
        public Roles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Role>().Property(x => x.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Role>().Property(x => x.Description).HasMaxLength(100);
        }
            


    }
}
