using System;

namespace findMin
{
    public class BisectionAlgorithm : IFindMinAlgorithm
    {
        public double FindMin(double a, double b, double eps, Func<double, double> f)
        {
            var iterationCounter = 0;
            var callCounter = 0;

            while (Math.Abs(b - a) >= eps)
            {
                var middle = (a + b) * 0.5;
                iterationCounter++;
                callCounter += 2;
                var x1 = middle - eps/4;
                var x2 = middle + eps/4;
                if (f(x1) > f(x2))
                {
                    a = x1;
                }
                else if (f(x1) < f(x2))
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                    b = x2;
                }
            }

            Console.WriteLine("Iteration: " + iterationCounter);
            Console.WriteLine("Calls: " + callCounter);
            var xMin = (a + b) * 0.5;
            Console.WriteLine(f(xMin));
            return xMin;
        }
    }
}