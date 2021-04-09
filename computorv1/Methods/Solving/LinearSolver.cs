using System;
using computorv1.Classes;

namespace computorv1.Methods.Solving
{
    public class LinearSolver
    {
        public LinearSolver()
        {
        }

        /// <summary>
        /// Solves a linear equation by using the reduced form of the polynomial.
        /// </summary>
        /// <param name="p"></param>
        public static void Solve(Polynomial p)
        {
            if (p.ReducedC.B == 0)
            {
                if (p.Options.Verbose)
                {
                    Console.WriteLine("Since there's no 'x' in this equation, it can't have a solution.");
                }
                else
                {
                    Console.WriteLine("This equation does not have any solution.");
                }
            }
            else
            {
                string solution = (-p.ReducedC.C / p.ReducedC.B).ToString();
                if (p.Options.Verbose)
                {
                    Console.WriteLine("This equation is linear (a * x + b). We can calcultate its solution by doing -b / a.\n" +
                        "x = -b / a\n" +
                        "x = " + (p.ReducedC.C < 0 ? (-p.ReducedC.C).ToString() : "-" + p.ReducedC.C.ToString()) + " / " + p.ReducedC.B +
                        "\nx = " + solution);
                }
                else
                {
                    Console.WriteLine("This equation has a one real solution.\nx = " + solution);
                }
            }
        }
    }
}
