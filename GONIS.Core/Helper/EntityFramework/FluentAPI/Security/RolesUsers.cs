using GONIS.Core.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GONIS.Core.Helper.EntityFramework.FluentAPI.Security
{
    public class RolesUsers : IFluentAPI
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Security.RolesUsers>() 
             .HasIndex(p => new { p.RoleId, p.UserId })
             .IsUnique(true);
        }

    }
}
