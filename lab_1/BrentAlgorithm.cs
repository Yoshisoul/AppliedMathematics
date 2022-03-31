using System;
using System.Runtime.Intrinsics.Arm;

namespace findMin
{
    public class BrentAlgorithm : IFindMinAlgorithm
    {
        private double Aproximation(double x1, double x2, double x3, double f1, double f2, double f3)
        {
            if (2 * ((x2 - x1) * (f2 - f3) - (x2 - x3) * (f2 - f1)) == 0)
            {
                return 0;
            }
            else
            {
                var u = x2 - (Math.Pow((x2 - x1), 2) * (f2 - f3) - Math.Pow((x2 - x3), 2) * (f2 - f1)) /
                    (2 * ((x2 - x1) * (f2 - f3) - (x2 - x3) * (f2 - f1)));

                return u;
            }
        }
        
        public double FindMin(double a, double b, double eps, Func<double, double> f)
        {
            var iterationCounter = 0;
            var callCounter = 0;
            
            var ratio = (Math.Sqrt(5) - 1) / 2;

            double x, w, v, dp, dc, fx, fw, fv, g, u, fu;
            x = w = v = a + ratio * (b - a);
            dp = dc = b - a;
            fx = fw = fv = f(x);

            callCounter++;
            while (b - a > eps)
            {
                iterationCounter++;
                g = dp / 2;
                dp = dc;
                u = Aproximation(x, w, v, fx, fw, fv);
                if ((u == 0) || 
                    ((a <= u && u <= b) != true) ||
                    (Math.Abs(u - x) > g))
                {
                    if (x < ((a + b) / 2))
                    {
                        u = x + ratio * (b - x);
                        dp = b - x;
                    }
                    else
                    {
                        u = x - ratio * (x - a);
                        dp = x - a;
                    }
                }

                fu = f(u);
                callCounter++;
                dc = Math.Abs(u - x);
                if (fu > fx)
                {
                    if (u < x)
                    {
                        a = u;
                    }
                    else
                    {
                        b = u;
                    }

                    if (fu <= fw || w == x)
                    {
                        v = w;
                        w = u;
                        fv = fw;
                        fw = fu;
                    }
                    else if (fu <= fv || v == x || v == w)
                    {
                        v = u;
                        fv = fu;
                    }
                }
                else
                {
                    if (u < x)
                    {
                        b = x;
                    }
                    else
                    {
                        a = x;
                    }

                    v = w;
                    w = x;
                    x = u;
                    fv = fw;
                    fw = fx;
                }
            }

            Console.WriteLine("Iteration: " + iterationCounter);
            Console.WriteLine("Calls: " + callCounter);
            Console.WriteLine(f(x));
            return x;
        }
    }
}