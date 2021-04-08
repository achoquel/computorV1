using System;
using System.Text.RegularExpressions;
using computorv1.Classes;
using computorv1.Methods.Parsing;

namespace computorv1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO : Remove
            string[] test = new string[2]
            {
                "dd",
                "x^2 + 3 = x^2 - 8"
            };

            if (BasicParse(test))
            {
                Polynomial p = Polynomial.Parse(test[1]);
                if (p.IsValid)
                {
                    p.Solve();
                }
                else
                {
                    Console.WriteLine("The provided equation is not well formated.");
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
            Console.WriteLine("Input is empty. Type \"./computorv1 help\" for more informations.");
            return false;
        }

        /// <summary>
        /// Handles the "help" command
        /// </summary>
        private static void Help()
        {
            Console.WriteLine("send help please");
        }
    }
}