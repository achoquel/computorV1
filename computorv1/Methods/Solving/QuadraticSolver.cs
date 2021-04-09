using System;
using computorv1.Classes;
using computorv1.Methods.Tools;

namespace computorv1.Methods.Solving
{
    public class QuadraticSolver
    {
        public QuadraticSolver()
        {
        }

        /// <summary>
        /// Solves a quadratic equation by using the reduced form of the Polynomial.
        /// </summary>
        /// <param name="p"></param>
        public static void Solve(Polynomial p)
        {
            float delta = p.ReducedC.B * p.ReducedC.B - 4 * p.ReducedC.A * p.ReducedC.C;
            if (p.Options.Verbose)
            {
                Console.WriteLine("Calculating the discriminant (Delta):\nDelta = b^2 - 4 * a * c\n      = " + p.ReducedC.B.ToString() + "^2 - 4 * " + p.ReducedC.A.ToString() + " * " + p.ReducedC.C.ToString()
                                    + "\n      = " + delta.ToString() + "\n");
            }
            if (delta == 0)
            {
                string solution = (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString();
                if (solution == "-0")
                    solution = "0";
                if (p.Options.Verbose)
                {
                    Console.WriteLine("The discriminant is equal to 0. It means that the equation has one real solution, that we can obtain by doing\n" +
                                      "x = -b / (2 * a)\n" +
                                      "x = " + (p.ReducedC.B < 0 ? "-" + p.ReducedC.B.ToString() : p.ReducedC.B.ToString()) + " / (2 * " + p.ReducedC.A.ToString() +
                                    ")\nx = " + solution);
                }
                else
                {
                    Console.WriteLine("Delta = 0.\nThe equation has one real solutions.\nx = " + solution);
                }
            }
            else if (delta > 0)
            {

                string x1 = ((-p.ReducedC.B - MathTools.Sqrt(delta)) / (2f * p.ReducedC.A)).ToString();
                if (x1 == "-0")
                    x1 = "0";
                string x2 = ((-p.ReducedC.B + MathTools.Sqrt(delta)) / (2f * p.ReducedC.A)).ToString();
                if (x2 == "-0")
                    x2 = "0";
                if (p.Options.Verbose)
                {
                    Console.WriteLine("The discriminant is strictly positive. It means that the equation has two real solutions, that we can obtain by doing\n" +
                                      "x1 = (-b - sqrt(Delta)) / (2 * a)\n" +
                                      "x1 = (" + (p.ReducedC.B < 0 ? (-p.ReducedC.B).ToString() : "-" + p.ReducedC.B.ToString()) + " - sqrt(" + delta.ToString() + ")) / (2 * " + p.ReducedC.A.ToString() + ")\n" +
                                      "x1 = " + x1 + "\n\n" +
                                      "x2 = (-b + sqrt(Delta)) / (2 * a)\n" +
                                      "x2 = (" + (p.ReducedC.B < 0 ? (-p.ReducedC.B).ToString() : "-" + p.ReducedC.B.ToString()) + " + sqrt(" + delta.ToString() + ")) / (2 * " + p.ReducedC.A.ToString() + ")\n" +
                                      "x2 = " + x2);
                }
                else
                {
                    Console.WriteLine("Delta is stricly positive (" + delta + ").\nThe equation has two real solutions.\nx1 = " + x1 + "\nx2 = " + x2);
                }
            }
            else
            {
                string x1 = (p.ReducedC.B != 0 ? (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString() : "") + " - " + (MathTools.Sqrt(-delta) / (2f * p.ReducedC.A)).ToString() + "i";
                string x2 = (p.ReducedC.B != 0 ? (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString() : "") + " + " + (MathTools.Sqrt(-delta) / (2f * p.ReducedC.A)).ToString() + "i";
                if (p.Options.Verbose)
                {
                    Console.WriteLine("The discriminant is strictly negative. It means that the equation has two complex solutions, that we can obtain by doing\n" +
                                      "x1 = (-b - sqrt(Delta)i) / (2 * a)\n" +
                                      "x1 = (" + (p.ReducedC.B < 0 ? (-p.ReducedC.B).ToString() : "-" + p.ReducedC.B.ToString()) + " - sqrt(" + delta.ToString() + ")i) / (2 * " + p.ReducedC.A.ToString() + ")\n" +
                                      "x1 = " + x1 + "\n\n" +
                                      "x2 = (-b + sqrt(Delta)i) / (2 * a)\n" +
                                      "x2 = (" + (p.ReducedC.B < 0 ? (-p.ReducedC.B).ToString() : "-" + p.ReducedC.B.ToString()) + " + sqrt(" + delta.ToString() + ")i) / (2 * " + p.ReducedC.A.ToString() + ")\n" +
                                      "x2 = " + x2);
                }
                else
                {
                    Console.WriteLine("Delta is strictly negative (" + delta.ToString() + ").\nThe equation has two complex solutions.\nx1 = " + x1 + "\nx2 = " + x2);
                }
            }
        }
    }
}
