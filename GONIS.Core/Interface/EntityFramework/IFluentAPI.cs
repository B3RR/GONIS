using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Interface.EntityFramework
{
    public interface IFluentAPI
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
