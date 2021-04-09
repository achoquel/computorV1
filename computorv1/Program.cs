using System;
using System.Text.RegularExpressions;
using computorv1.Classes;
using computorv1.Methods.Parsing;
using computorv1.Methods.Tools;

namespace computorv1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (BasicParse(args))
            {
                Polynomial p = Polynomial.Parse(args[1], args[2]?.ToString());
                if (p.IsValid)
                {
                    p.Solve();
                }
            }
        }

        /// <summary>
        /// Handles the basic parsing of the passed args
        /// </summary>
        /// <param name="args">Table of arguments to check</param>
        /// <returns></returns>
        private static bool BasicParse(string[] args)
        {
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                if (args[1].Trim() == "help")
                {
                    Help();
                    return false;
                }
                else
                    return true;
            }
            ErrorTools.DisplayError("Error: Input is empty. Type \"./computorv1 help\" for more informations.");
            return false;
        }

        /// <summary>
        /// Handles the "help" command
        /// </summary>
        private static void Help()
        {
            Console.WriteLine("----------------------------------\n" +
                              "    ComputorV1 - by achoquel\n" +
                              "----------------------------------\n" +
                              "This program will help you to solve some polynomial equations. It accepts linear and quadratic equations.\n" +
                              "To do so, type ./computorv1 \"equation\" [-options]\n\n" +
                              "The equation must contain at least a 'x' and a '='.\n" +
                              "The program accepts two syntaxes, you can either write each power of x, or just write your equation naturally, or even both at the same time.\n" +
                              "For example:\n" +
                              "2 * x ^ 2 + 1 * x ^ 0 = 3 * x ^ 1\n" +
                              "2x^2 + 1 = 3x\n" +
                              "2x^2 + 1 = 3 * x^1\n\n" +
                              "Available options:\n" +
                              "-v (Verbose): Display some intermediates steps during the solving.\n" +
                              "-n (Natural): Display the equations with a natural format (ex: 2x^2 * 3x + 1 = -2x)");
        }
    }
}