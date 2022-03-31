using System;

namespace findMin
{
    public class ParabolasAlgorithm : IFindMinAlgorithm
    {
        public double FindMin(double a, double c, double eps, Func<double, double> f)
        {
            var iterationCounter = 0;
            var callCounter = 0;
            
            var b = (a + c) / 2;
            var fa = f(a);
            var fc = f(c);
            var fb = f(b);
            double u = 0;
            
            while (c - a > eps) {
                iterationCounter++;
        
                u = b - (Math.Pow(b - a, 2) * (fb - fc) - Math.Pow(b - c, 2) * (fb - fa)) 
                    / (2 * ((b - a) * (fb - fc) - (b - c) * (fb - fa)));
        
                if (!(u >= a && u <= c)) {
                    break;
                }

                if (Math.Abs(u - ((c - a) / 2)) < eps) {
                    break;
                }

                double fu = f(u);
                callCounter += 4;
                
                if (fu > fb) {
                    if (u > b) {
                        c = u;
                        fc = fu;
                    }
                    else {
                        a = u;
                        fa = fu;
                    }
                }
                else {
                    if (b > u) {
                        c = b;
                        fc = fb;
                    }
                    else {
                        a = b;
                        fa = fb;
                    }
            
                    b = u;
                    fb = fu;
                }
            }

            Console.WriteLine("Iteration: " + iterationCounter);
            Console.WriteLine("Calls: " + callCounter);
            return (a + c) / 2;
        }
        
    }
}