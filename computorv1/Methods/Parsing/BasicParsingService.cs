﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using computorv1.Classes;

namespace computorv1.Methods.Parsing
{
    public class BasicParsingService
    {
        private static readonly string[] AUTHORIZED_POWERS = { "0", "1", "2" };

        public BasicParsingService()
        {
        }

        /// <summary>
        /// Takes the string representation of the equation, and verifies that it has a "=", a "x", removes all whitespaces and verifies the syntax
        /// </summary>
        /// <param name="e">The string representation of the equation</param>
        /// <returns></returns>
        public static bool CheckFullEquation(string e)
        {
            //We verify if the equation is not empty, if it has a '=' and a 'x'
            if (!string.IsNullOrEmpty(e) && e.Contains('=') && (e.Contains('x')))
            {
                //We remove every whitespace from the equation to make it easier to verify
                e = Regex.Replace(e, @"\s+", "");

                //We verify if the equation only contains allowed characters
                if (CheckForbiddenSyntax(e))
                    return true;
            }
            Console.WriteLine("Input is invalid. Type \"./computorv1 help\" for more informations.");
            return false;
        }

        /// <summary>
        /// Extract and parses each sides of the equation, and retrieves all of the equation coefficients
        /// </summary>
        /// <param name="p">The polynomial</param>
        public static void HandleSidesParsing(ref Polynomial p)
        {
            //We Parse our full equation to extract and verify both sides of it
            ExtractAndParseSides(ref p);
            
            //If everything is ok, we assign the coefficients
            if (p.IsValid)
            {
                //We split each sides to separate x^2, x^1 and x^0
                var leftSplit = Regex.Split(p.LeftSide, "(?=[])([+-])").Where(part => !string.IsNullOrEmpty(part)).ToArray();
                var rightSplit = Regex.Split(p.RightSide, "(?=[])([+-])").Where(part => !string.IsNullOrEmpty(part)).ToArray();

                //We assign the coefficients as floats to our Polynomial
                p.LeftC = MathParsing.ParseCoefficient(leftSplit);
                p.RightC = MathParsing.ParseCoefficient(rightSplit);

                if (p.LeftC == null || p.RightC == null)
                {
                    p.IsValid = false;
                }

                //Console.WriteLine("Left: a = " + p.LeftC.A + " b = " + p.LeftC.B + " c = " + p.LeftC.C + "\n");
                //Console.WriteLine("Right: a = " + p.RightC.A + " b = " + p.RightC.B + " c = " + p.RightC.C + "\n");
            }
        }

        /// <summary>
        /// Parses the full equation to verify if each side of it is correctly formed
        /// </summary>
        /// <param name="p"></param>
        private static void ExtractAndParseSides(ref Polynomial p)
        {
            var parts = p.Equation.Split('=', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && !string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]))
            {
                //We assign both parts to our Polynomial object
                p.LeftSide = parts[0].Trim();
                p.RightSide = parts[1].Trim();

                //We split each part to separate each component of the parts, and we get rid of empty strings
                List<string[]> splittedParts = new List<string[]>()
                {
                    Regex.Split(p.LeftSide, "(?=[])([+-])").Where(part => !string.IsNullOrEmpty(part)).ToArray(),
                    Regex.Split(p.RightSide, "(?=[])([+-])").Where(part => !string.IsNullOrEmpty(part)).ToArray()
                };
                foreach (var spart in splittedParts)
                {
                    //We check if we have a correct ammount of parts before we parse them
                    //We also verify that we only have one or zero parts with the same x power
                    if (spart.Length == 0 || spart.Length > 3 || !CheckForXPowers(spart))
                    {
                        p.IsValid = false;
                    }
                }
            }
            else
            {
                p.IsValid = false;
            }
        }

        /// <summary>
        /// Verifies the equation syntax and content
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static bool CheckForbiddenSyntax(string e)
        {
            //We check for forbidden characters
            if (!e.All(c => "0123456789+-=^/*x.".Contains(c)))
                return false;
            //We check for double operators
            if (e.Contains("++") || e.Contains("**") || e.Contains("--") || e.Contains("-+") || e.Contains("+-") || e.Contains("..") || e.Contains("//") || e.Contains("x/"))
                return false;
            //We check for double x
            if (e.Contains("xx"))
                return false;
            return true;
        }

        /// <summary>
        /// Verifies that we don't have the same power of X defined in the same side of the equation
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        private static bool CheckForXPowers(string[] parts)
        {
            bool x2 = false;
            bool x1 = false;
            bool x0 = false;

            foreach (var part in parts)
            {
                var exp = MathParsing.DetectPower(part);
                    
                if (!AUTHORIZED_POWERS.Any(e => e == exp))
                {
                    return false;
                }

                //Here, we check if a x power has already been found
                if (exp == "2" && x2 == false)
                {
                    x2 = true;
                }
                else if (exp == "1" && x1 == false)
                {
                    x1 = true;
                }
                else if (exp == "0" && x0 == false)
                {
                    x0 = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}