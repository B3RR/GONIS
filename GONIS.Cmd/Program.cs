using System;
using GONIS.Core.Helper;

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
            
            ConsoleHelper.WriteUnderLine();
            ConsoleHelper.WriteTextOnMiddle("Привет");
            Console.ReadKey();
            ConsoleHelper.WriteTextOnMiddle("Привет");

        }
    }
}
