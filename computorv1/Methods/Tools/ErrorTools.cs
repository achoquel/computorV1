using System;
namespace computorv1.Methods.Tools
{
    public class ErrorTools
    {
        public ErrorTools()
        {
        }

        /// <summary>
        /// Display an error in red, and turn back to grey the color of the output
        /// </summary>
        /// <param name="message"></param>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
