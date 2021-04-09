using System;
namespace computorv1.Classes
{
    public class Options
    {
        public Options()
        {
        }

        /// <summary>
        /// If true, will display the results in a more natural way (ex: 2x^2 + 3x + 1 = 4x^2),
        /// otherwise it will be displayed as in the subject (ex: 2 * x^2 + 3 * x^1 + 1 * x^0 = 4 * x^2)
        /// </summary>
        public bool Natural { get; set; } = false;

        /// <summary>
        /// If true, will display the the intermediate steps of the equation resolving
        /// </summary>
        public bool Verbose { get; set; } = false;
    }
}
