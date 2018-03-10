using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Helper.EntityFramework
{
    public class Migration : IDesignTimeDbContextFactory<DataBase>
    {


        public DataBase CreateDbContext(string[] args)
        {
            var connectionString = ConfigurationHelper.GetConnectionString("Entity");

            var optionsBuilder = new DbContextOptionsBuilder<DataBase>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataBase(optionsBuilder.Options);
        }

    }
}
