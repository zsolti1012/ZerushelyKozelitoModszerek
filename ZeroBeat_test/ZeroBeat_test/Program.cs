using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NummatDLL;

namespace ZeroBeat_test
{
    class Program
    {// The function is x^3 - x^2 + 2 
        static double f(double x)
        {
            return 3.0 * Math.Sin(x) + 1.0;
            
        }
        // which is 3*x^x - 2*x 
        static double df(double x)
        {
            return 3.0 * Math.Cos(x) ;
           
        }


        static void Main(string[] args)
        {
           
            double a = 1.0;
            double b = 5.0;
            double delta = 0.00001;

            Console.WriteLine("Intervallumfelező\tZérushely: x={0}",
               ZeroBeat.IntervalHalfing(a, b, delta, f));

            Console.WriteLine("Intervallumfelező\tZérushely: x={0}",
          ZeroBeat.IntervalHalfing2(a, b, delta, f));

            Console.WriteLine("Húr-módszer\t\tZérushely: x={0}", ZeroBeat.StringMethod(a, b, delta, f));
            Console.WriteLine("Közelítő módszer\tZérushely: x={0}",ZeroBeat.TangentMethod(a,delta,f,df));


            Console.WriteLine("Fixpontinteráció\tZérushely: x={0}",ZeroBeat.FixPointIteration(1.5,x=>Math.Sin(x)+x,delta));
            Console.WriteLine("Fixpontiterációrek\tZérushely: x={0}", ZeroBeat.FixPointRecursion(1.5, x => Math.Sin(x) + x, delta));
            Console.ReadLine();
            
           
        }


    }

    //-------------------------------------------------------------------------
    
}
