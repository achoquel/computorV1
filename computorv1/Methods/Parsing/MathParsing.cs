using System;
using System.Linq;
using System.Text.RegularExpressions;
using computorv1.Classes;
using computorv1.Methods.Tools;

namespace computorv1.Methods.Parsing
{
    public class MathParsing
    {
        public MathParsing()
        {
        }

        /// <summary>
        /// Parses a splitted side of an equation and extract its coefficients.
        /// </summary>
        /// <param name="split"></param>
        /// <returns></returns>
        public static Coefficients ParseCoefficient(string[] split)
        {
            float a = 0, b = 0, c = 0;
            bool aValid = true, bValid = true, cValid = true;

            foreach (var part in split)
            {
                //We remove any * from the part to make it easier to parse
                var tpart = Regex.Replace(part, @"\*+", "");
                string exp = DetectPower(part);
                if (tpart.Contains('x'))
                {
                    var splittedPart = Regex.Split(tpart, "(x)").Where(part => !string.IsNullOrEmpty(part)).ToArray();
                    if(splittedPart[0] == "x" || splittedPart[0] == "+")
                    {
                        splittedPart[0] = "1";
                    }
                    else if (splittedPart[0] == "-")
                    {
                        splittedPart[0] = "-1";
                    }
                    //Handling of fractional form
                    if (splittedPart[0].Contains("/"))
                    {
                        splittedPart[0] = ParseFractionnalForm(splittedPart[0]);
                    }
                    if (exp == "2")
                    {
                        aValid = float.TryParse(splittedPart[0], out a);
                    }
                    else if (exp == "1")
                    {
                        bValid = float.TryParse(splittedPart[0], out b);
                    }
                    else
                    {
                        cValid = float.TryParse(splittedPart[0], out c);
                    }
                }
                else
                {
                    cValid = float.TryParse(part, out c);
                }
            }
            if (aValid && bValid && cValid)
            {
                return new Coefficients()
                {
                    A = a,
                    B = b,
                    C = c
                };
            }
            ErrorTools.DisplayError("Error: An error occured during the parsing for: " + string.Concat(split));
            return null;
        }

        /// <summary>
        /// Takes a component of a side of the equation and detects the power of X
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public static string DetectPower(string part)
        {
            if (part.Contains('x'))
            {
                var powerSplit = part.Split('^', StringSplitOptions.RemoveEmptyEntries);
                string exp;
                //If the part is looking like 2*x^0, we simply take the last part of the split
                if (powerSplit.Length == 2)
                    exp = powerSplit[1];
                else
                {
                    //Otherwise, if we have something like 2x, we check that x is the last char of the part and we set its power to 1, else we set it to -1 because it is invalid, we can't have things like x2 or x- etc
                    exp = powerSplit[0].LastOrDefault() == 'x' ? "1" : "-1";
                }
                return exp;
            }
            return "0";
        }

        /// <summary>
        /// Gets a fraction and transform it into a numerical format
        /// </summary>
        /// <param name="frac"></param>
        /// <returns></returns>
        private static string ParseFractionnalForm(string frac)
        {
            var split = frac.Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 2)
            {
                float a = 0 , b = 0;

                if (float.TryParse(split[0], out a) && float.TryParse(split[1], out b) && b != 0)
                {
                    return (a / b).ToString();
                }
                else if (b == 0)
                {
                    ErrorTools.DisplayError("Error: Division by 0.");
                }
            }
            return null;
        }
    }
}