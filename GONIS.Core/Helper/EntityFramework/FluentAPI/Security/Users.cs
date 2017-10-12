using GONIS.Core.Interface.EntityFramework;
using GONIS.Core.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Helper.EntityFramework.FluentAPI.Security
{
    public class Users
    {
        public Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FIO).HasMaxLength(255);
        }
    }
}
