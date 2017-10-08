using System;

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
            Console.WriteLine(Core.Helper.ConsoleHelper.ReadLine());
            if (Core.Helper.ConsoleHelper.ReadYesOrNo())
            {
                Console.WriteLine("да"); 
            }
            else
            {
                Console.WriteLine("нет");
            }

        }
    }
}
