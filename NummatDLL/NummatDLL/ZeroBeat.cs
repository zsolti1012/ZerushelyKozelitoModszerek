using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NummatDLL
{
    public class ZeroBeat
    {

        public delegate double Fgv(double x);

        public static double IntervalHalfing(double a, double b, double delta, Fgv f)
        {
            if (f(a) * f(b) >= 0) throw new Exception("There are no zero beat ....");
            double c = (a + b) / 2;


            if (Math.Abs(f(c)) < delta)
            {
                return c;
            }

            else
            {
                if (f(a) * f(c) > 0)
                {
                    return IntervalHalfing(c, b, delta, f);
                }

                else
                {
                    return IntervalHalfing(a, c, delta, f);
                }

            }


        }

        public static double IntervalHalfing2(double a, double b, double delta, Fgv f)
        {
            //Iteratív

            if (f(a) * f(b) >= 0) throw new Exception("There are no zero beat ....");
            double c;

            do
            {
                c = (a + b) / 2;
                if (f(a) * f(c) > 0) a = c;
                else b = c;

            } while (Math.Abs(f(c)) >= delta);

            return c;

        }

        public static double StringMethod(double a, double b, double delta, Func<double, double> f)
        {
            if (f(a) * f(b) >= 0) throw new Exception("There are no zero beat ....");
            double c;
            double formula = (a - f(a)) * ((b - a) / (f(b) - f(a)));

            do
            {
                c = (a * f(b) - b * f(a)) / (f(b) - f(a));   //a - f(a) * ((b - a) / (f(b) - f(a)));
                if (f(c) * f(a) < 0) b = c;
                if (f(c) * f(b) < 0) a = c;

            } while (Math.Abs(b - a) >= delta/* c-formula>=delta*/);
            return c;
        }

        public static double TangentMethod(double a, double delta, Func<double, double> f, Func<double, double> df)
        {


            double h = f(a) / df(a);
            while (Math.Abs(h) >= delta)
            {
                h = f(a) / df(a);


                a = a - h;
            }
            return a;

        }

        public static int limit = 1000;
        public static double FixPointIteration(double x0, Func<double, double> g, double delta)
        {

            int db = 0;
            int iter = 0;
            while (Math.Abs(g(x0) - x0) >= delta)
            {

                iter++;

                x0 = g(x0);
                if (iter >= 1000)
                {
                    throw new Exception("Not valid g!");
                }
            }
            return g(x0);


        }



        public static double FixPointRecursion(double x0, Func<double, double> g, double delta)
        {
            double x1 = g(x0);

            if (Math.Abs(x1 - x0) < delta)
            {
                return x1;
            }

            return FixPointRecursion(x1, g, delta);

        }

    }
}
    

