using System;
namespace GONIS.Core.Helper
{
    public static class ConsoleHelper
    {
        public static string ReadLine()
        {
            Console.Write("Input text:");
            return Console.ReadLine().Trim();
        }
        public static bool ReadYesOrNo()
        {
            Console.Write("Input 'n' or 'y':");
            var value = Console.ReadLine().ToLower();
            if (value == "y")
            {
                return true;
            }
            if (value == "n")
            {
                return false;
            }
            else
            {
                return ReadYesOrNo();
            }
        }

    }
}
