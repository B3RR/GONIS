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
            EntityFramework.InsertFakeData();
            EntityFramework.SelectFakeData();
            Console.ReadKey();
        }
       

    }
}