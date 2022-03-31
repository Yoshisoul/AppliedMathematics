using System;

namespace findMin
{
    public interface IFindMinAlgorithm
    { 
        double FindMin(double a, double b, double eps, Func<double, double> f);
    }
}