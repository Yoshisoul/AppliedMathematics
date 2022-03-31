using System;

namespace findMin
{
    public class FibonacciAlgorithm : IFindMinAlgorithm
    {
        private double GetNextFibonacciINumber(int num)
        {
            return Math.Round(Math.Pow((1 + Math.Sqrt(5)) / 2, num) - Math.Pow((1 - Math.Sqrt(5)) / 2, num) / Math.Sqrt(5));
        }

        public double FindMin(double a, double b, double eps, Func<double, double> f)
        {
            var n = 1;
            while (GetNextFibonacciINumber(n + 2) <= (b - a) / eps)
            {
                n += 1;
            }

            var x1 = a + GetNextFibonacciINumber(n) / GetNextFibonacciINumber(n + 2) * (b - a);
            var x2 = a + GetNextFibonacciINumber(n + 1) / GetNextFibonacciINumber(n + 2) * (b - a);
            var y1 = f(x1);
            var y2 = f(x2);
            var callCounter = 2;
            var iterationCounter = 0;

            while (b - a > eps && a < b)
            {
                iterationCounter++;
                if (y1 > y2)
                {
                    n--;
                    a = x1;
                    x1 = x2;
                    x2 = a + GetNextFibonacciINumber(n + 1) / GetNextFibonacciINumber(n + 2) * (b - a);
                    y1 = y2;
                    y2 = f(x2);
                    callCounter++;
                }
                else
                {
                    n--;
                    b = x2;
                    x2 = x1;
                    x1 = a + GetNextFibonacciINumber(n) / GetNextFibonacciINumber(n + 2) * (b - a);
                    y2 = y1;
                    y1 = f(x1);
                    callCounter++;
                }
            }

            var result = (a + b) / 2;
            Console.WriteLine("Iteration: " + iterationCounter);
            Console.WriteLine("Calls: " + callCounter);
            Console.WriteLine(f(result));
            return result;
        }
    }
}