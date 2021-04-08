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
                Console.WriteLine("This equation does not have any solution.");
            }
            else
            {
                string solution = (-p.ReducedC.C / p.ReducedC.B).ToString();
                Console.WriteLine("This equation has a one real solution.\nx = " + solution);
            }
        }
    }
}
