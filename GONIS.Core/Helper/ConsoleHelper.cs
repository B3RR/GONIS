using System;
namespace GONIS.Core.Helper
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Read text from Console
        /// </summary>
        /// <returns>The line.</returns>
        public static string ReadLine()
        {
            Console.Write("Input text:");
            return Console.ReadLine().Trim();
        }
        /// <summary>
        /// Reads the yes or no.
        /// </summary>
        /// <returns><c>true</c>, if "yes" or "y", <c>false</c> if "no" or "n".</returns>
        public static bool ReadYesOrNo()
        {
            Console.Write("Input 'n' or 'y':");
            var value = Console.ReadLine().ToLower();
            if (value.Equals("y")||value.Equals("yes"))
            {
                return true;
            }
            else if (value.Equals("n")||value.Equals("no"))
            {
                return false;
            }
            else
            {
                return ReadYesOrNo();
            }
        }
        /// <summary>
        /// Writes the under line.
        /// </summary>
        public static void WriteUnderLine()
        {
            var width = Console.WindowWidth;
            Console.WriteLine(new String('-',width));
        }
        /// <summary>
        /// Writes the text on middle.
        /// </summary>
        /// <param name="text">Text.</param>
        public static void WriteTextOnMiddle(string text)
        {
			var width = Console.WindowWidth;
			if (text.Length < width)
			{
				text = text.PadLeft((width - text.Length) / 2 + text.Length, ' ');
			}
			Console.WriteLine(text);
        }

    }
}
