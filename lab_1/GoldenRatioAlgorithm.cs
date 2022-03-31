using System;

namespace findMin
{
    public class GoldenRatioAlgorithm : IFindMinAlgorithm
    {
        public double FindMin(double a, double b, double eps, Func<double, double> f)
        {
            var phi = (3 - Math.Sqrt(5)) * 0.5;
            var iterationCounter = 0;
            var callCounter = 2;
            var x1 = a + phi * (b - a);
            var x2 = b - phi * (b - a);
            var fx1 = f(x1);
            var fx2 = f(x2);
            while (b - a >= eps)
            {
                if (fx1 >= fx2)
                {
                    a = x1;
                    x1 = x2;
                    fx1 = fx2;
                    x2 = b - phi * (b - a);
                    fx2 = f(x2);
                }
                else
                {
                    b = x2;
                    x2 = x1;
                    fx2 = fx1;
                    x1 = a + phi * (b - a);
                    fx1 = f(x1);
                }
                
                iterationCounter++;
                callCounter++;
            }

            var xMin = 0.5 * (a + b);
            Console.WriteLine("Iteration: " + iterationCounter);
            Console.WriteLine("Calls: " + callCounter);
            Console.WriteLine(f(xMin));
            return xMin;
        }
    }
}