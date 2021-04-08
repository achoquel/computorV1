using System;
namespace computorv1.Classes
{
    public class Coefficients
    {
        public Coefficients()
        {
        }

        //Coefficient for x^2
        public float A { get; set; } = 0;

        //Coefficient for x^1
        public float B { get; set; } = 0;

        //Coefficient for x^0
        public float C { get; set; } = 0;

        //+ operator between two Coefficients
        public static Coefficients operator -(Coefficients a, Coefficients b)
        {
            return new Coefficients()
            {
                A = a.A - b.A,
                B = a.B - b.B,
                C = a.C - b.C
            };
        }

        public override string ToString()
        {
            string str = null;

            if (this.A != 0)
                str += this.A.ToString() + " * x ^ 2 ";
            if (this.B != 0)
            {
                //To have a pretty display, we handle this case to display n * x^2 - k * x^1 instead of n * x^2 -k * x^1
                if (this.B > 0)
                {
                    if (this.A != 0)
                        str += "+ ";
                    str += this.B.ToString() + " * x ^ 1 ";
                }
                else
                {
                    if (this.A != 0)
                    {
                        str += "- ";
                        str += (-this.B).ToString() + " * x ^ 1 ";
                    }
                    else
                        str += this.B.ToString() + " * x ^ 1 ";
                }
            }
            if (this.C != 0)
            {
                if (this.C > 0)
                {
                    if (this.B != 0 || this.A != 0)
                        str += "+ ";
                    str += this.C.ToString() + " * x ^ 0 ";
                }
                else
                {
                    if (this.B != 0 || this.A != 0)
                    {
                        str += "- ";
                        str += (-this.C).ToString() + " * x ^ 0 ";
                    }
                    else
                        str += this.C.ToString() + " * x ^ 0 ";
                }
            }
            return str ?? "0";
        }

        /// <summary>
        /// ToString that displays the coefficients in a natural way (2x^2 + 3x instead of 2 * x ^ 2 + 3 * x ^ 1)
        /// </summary>
        /// <returns></returns>
        public string ToStringNatural()
        {
            string str = null;

            if (this.A != 0)
                str += this.A.ToString() + "x^2 ";
            if (this.B != 0)
            {
                //To have a pretty display, we handle this case to display n * x^2 - k * x instead of n * x^2 -k * x
                if (this.B > 0)
                {
                    if (this.A != 0)
                        str += "+ ";
                    str += this.B.ToString() + "x ";
                }
                else
                {
                    if (this.A != 0)
                    {
                        str += "- ";
                        str += (-this.B).ToString() + "x ";
                    }
                    else
                        str += this.B.ToString() + "x ";
                }
            }
            if (this.C != 0)
            {
                if (this.C > 0)
                {
                    if (this.B != 0 || this.A != 0)
                        str += "+ ";
                    str += this.C.ToString();
                }
                else
                {
                    if (this.B != 0 || this.A != 0)
                    {
                        str += "- ";
                        str += (-this.C).ToString();
                    }
                    else
                        str += this.C.ToString();
                }
            }
            return str ?? "0";
        }
    }
}
