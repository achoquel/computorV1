using System;
using System.Text.RegularExpressions;
using computorv1.Methods.Parsing;
using computorv1.Methods.Solving;
using computorv1.Methods.Tools;

namespace computorv1.Classes
{
    public class Polynomial
    {
        public Polynomial()
        {
        }

        /// <summary>
        /// The complete equation
        /// </summary>
        public string Equation { get; set; }

        /// <summary>
        /// The degree of the equation
        /// </summary>
        public int Degree
        {
            get
            {
                if (ReducedC.A != 0)
                    return 2;
                else if (ReducedC.B != 0 && ReducedC.A == 0)
                    return 1;
                return 0;
            }
        }

        /// <summary>
        /// If the given equation is valid or not
        /// </summary>
        public bool IsValid { get; set; } = true;

        /// <summary>
        /// If the given equation is solvable or not
        /// </summary>
        public bool IsSolvable { get; set; } = true;

        /// <summary>
        /// The left part of the equation
        /// </summary>
        public string LeftSide { get; set; }

        /// <summary>
        /// The left coefficients of the equation (LeftC.A * x^2 + LeftC.B * x + LeftC.C = Right)
        /// </summary>
        public Coefficients LeftC { get; set; } = new Coefficients();

        /// <summary>
        /// The right part of the equation
        /// </summary>
        public string RightSide { get; set; }

        /// <summary>
        /// The right coefficients of the equation (Left = RightC.A * x^2 + RightC.B * x + RightC.C)
        /// </summary>
        public Coefficients RightC { get; set; } = new Coefficients();

        /// <summary>
        /// The coefficients of the reduced equation (ReducedC.A * x^2 + ReducedC.B * x + ReducedC.C = 0)
        /// </summary>
        public Coefficients ReducedC
        {
            get
            {
                return LeftC - RightC;
            }
        }

        /// <summary>
        /// The options for the display of the results
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Handle the whole parsing of the equation.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Polynomial Parse(string e, string options)
        {
            //We remove whitespaces and we put every X to lowercase
            e = Regex.Replace(e, @"\s+", "").Replace('X', 'x');
            Polynomial p = new Polynomial()
            {
                Equation = e,
                IsValid = BasicParsingService.CheckFullEquation(e),
                Options = options != null ? BasicParsingService.ParseOptions(options) : new Options()
            };
            if(p.IsValid)
            {
                BasicParsingService.HandleSidesParsing(ref p);
            }
            return p;
        }

        /// <summary>
        /// Solves the given polynomial equation if it is correct and prints the results.
        /// </summary>
        public void Solve()
        {
            Console.WriteLine("Trying to resolve " + (this.Options.Natural ? this.LeftC.ToStringNatural() : this.LeftC.ToString()) + "= " + (this.Options.Natural ? this.RightC.ToStringNatural() : this.RightC.ToString()) +
                              ".\nThe Reduced form of this equation is " + (this.Options.Natural ? this.ReducedC.ToStringNatural() : this.ReducedC.ToString()) + "= 0.\n" +
                              "The Polynomial Degree of this equation is " + this.Degree.ToString() + "\n\n");
            if (this.LeftC.A == this.RightC.A && this.LeftC.B == this.RightC.B && this.LeftC.C == this.RightC.C)
            {
                Console.WriteLine("Every number is a solution for this equation.");
            }
            else
            {
                if (this.Degree == 1)
                {
                   LinearSolver.Solve(this);
                }
                else if (this.Degree == 2)
                {
                   QuadraticSolver.Solve(this);
                }
                else
                {
                    ErrorTools.DisplayError("Error: This equation can't be solved by computorV1.");
                }
            }
        }
    }
}
