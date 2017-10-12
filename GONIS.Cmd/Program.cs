using System;
using GONIS.Core.Helper;
using System.Data.SqlClient;
using System.Data;
using GONIS.Core.Helper.EntityFramework;
using GONIS.Core.Model.Security;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GONIS.Cmd
{
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            SelectFakeData();
            Console.ReadKey();
        }
        static void SelectFakeData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBase>();
            optionsBuilder.UseSqlServer("");


            using (var db = new DataContext(optionsBuilder.Options))
            {
                ConsoleHelper.WriteUnderLine();
  
                var users = db.Users.Get(x => x.Id > 0);
                var roles = db.Roles.Get(x => x.Id > 0);

                ConsoleHelper.WriteTextOnMiddle("List of objects");
                ConsoleHelper.WriteUnderLine();
                foreach (var u in users)
                {
                    Console.WriteLine($"User - {u.Login}");
                }
                ConsoleHelper.WriteUnderLine();
                foreach (var r in roles)
                {
                    Console.WriteLine($"Role - {r.Name}");
                }
                var rus = db.RolesUsers.Get(x=>x.Id>0);
                ConsoleHelper.WriteUnderLine();
                foreach (var ru in rus)
                {
                    Console.WriteLine($"User - {ru.User.Login} Role - {ru.Role.Description}");
                }
                ConsoleHelper.WriteUnderLine();
            }
        }

        static void InsertFakeData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBase>();
            optionsBuilder.UseSqlServer("");
            using (var db = new DataContext(optionsBuilder.Options))
            {
                db.Roles.Add(new Role { Name = "Admin", Description = "Administration" });
                db.Roles.Add(new Role { Name = "User", Description = "Formal User" });
                
                db.Commit();

                db.Users.Add(new User { Login = @"U_021L1", FIO = "Tom" });
                db.Users.Add(new User { Login = @"U_021L2", FIO = "Alice" });
                db.Users.Add(new User { Login = @"U_021L3", FIO = "Oleg" });
                db.Users.Add(new User { Login = @"U_021L4", FIO = "Dima" });
                db.Commit();

                var role = db.Roles.GetById(1);

                foreach (var u in db.Users.Get(u => u.Id > 0)) 
                {
                    db.RolesUsers.Add(new RolesUsers {User=u,Role=role });
                }

                var role2 = db.Roles.GetById(2);
                foreach (var u in db.Users.Get(u => u.Id > 2))
                {
                    db.RolesUsers.Add(new RolesUsers { User = u, Role = role2 });
                }
                db.Commit();
            }
        }

    }
}