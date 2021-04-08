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
            if (delta == 0)
            {
                string solution = (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString();
                Console.WriteLine("Delta = 0.\nThe equation has one real solutions.\nx = " + solution);
            }
            else if (delta > 0)
            {

                string x1 = ((-p.ReducedC.B - MathTools.Sqrt(delta)) / (2f * p.ReducedC.A)).ToString();
                string x2 = ((-p.ReducedC.B + MathTools.Sqrt(delta)) / (2f * p.ReducedC.A)).ToString();
                Console.WriteLine("Delta is stricly positive (" + delta + ").\nThe equation has two real solutions.\nx1 = " + x1 + "\nx2 = " + x2);
            }
            else
            {
                string x1 = (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString() + " - (i * " + (-delta).ToString() + "^0.5 / " + (2f * p.ReducedC.A).ToString() + ")";
                string x2 = (-p.ReducedC.B / (2f * p.ReducedC.A)).ToString() + " + (i * " + (-delta).ToString() + "^0.5 / " + (2f * p.ReducedC.A).ToString() + ")";
                Console.WriteLine("Delta is strictly negative(" + delta + ").\nThe equation has two complex solutions.\nx1 = " + x1 + "\nx2 = " + x2);
            }
        }
    }
}
