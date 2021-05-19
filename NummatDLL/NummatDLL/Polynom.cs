using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NummatDLL
{
    public class Polynom
    {

        public Polynom(params double [] coefficients)
        {
            this.coefficients = new double[coefficients.Length];
            for (int i = 0; i < coefficients.Length; i++)
            {
                this.coefficients[i] = coefficients[i];
            }
        }

        private double [] coefficients;

        public double[] Coefficients
        {
            get
            {
                double []temp=new double[coefficients.Length];
                for (int i = 0; i < coefficients.Length; i++)
                {
                    temp[i] = coefficients[i];
                }

                return temp;
            }
        }

        public double this[int index]
        {
            get { return coefficients[index]; }
            set { coefficients[index] = value; }
        }
        public override string ToString()
        {
            if (coefficients.Length == 0)
                throw new Exception("The are no coefficients!");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < coefficients.Length - 1; i++)
            {
                if (coefficients[i] != 0)
                {
                    if (i != 0)
                    {
                        if (coefficients[i] > 0) sb.Append(" + ");
                        else sb.Append(" - ");
                    }
                    else if (coefficients[i] < 0) sb.Append("-");

                    sb.Append(Math.Abs(coefficients[i]) + " * x");
                    if (i != coefficients.Length - 2)
                        sb.Append("^" + (coefficients.Length - i - 1));
                }
            }
            if (coefficients[coefficients.Length - 1] > 0) sb.Append(" + ");
            else sb.Append(" - ");
            sb.Append(coefficients[coefficients.Length - 1]);
            return sb.ToString();


            
        }

        //  Evaluate
        /*
         Függvény kiértékel (valós: X, valós []: P): valós
         * változók
         *  valós: s;
         *  egész: I;
         * Algoritmus
         *  s <- P[1]
         *  Iteráció: I <- 2..n
         *          s<- s*x + p[i];
         *  Iteráció_vége;
         *  Kiértékel <-s;
         Függvény_vége;
         */

        public double Evaulate(double x)
        {
            double s;
          

            s = coefficients[0];

            for (int i = 1; i < coefficients.Length; i++)
            {
                s = s * x + coefficients[i];
            }
            return s;
        }

        //Evaluate 2: klasszikus polinom kiértékelés
    }
}
