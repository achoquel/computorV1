using System;
namespace computorv1.Methods.Tools
{
    public class MathTools
    {
        public MathTools()
        {
        }

        /// <summary>
        /// Calculates the square root of a float.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float Sqrt(float n)
        {
            if (n < 0) return 0;

            float root = n / 3;
            int i;
            for (i = 0; i < 32; i++)
                root = (root + n / root) / 2;
            return root;
        }
    }
}
