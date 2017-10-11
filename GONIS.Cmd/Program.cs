using System;
using GONIS.Core.Helper;
using System.Data.SqlClient;
using System.Data;

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
           var dt=MSSqlAdoNetHelper.GetDataTableFromQuery("select 100","");
        }
    }
}
