using System;

namespace findMin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Searching minimum for interval a = 7, b = 8, epsylon = 0.0001");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new BisectionAlgorithm().FindMin(7,8,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new GoldenRatioAlgorithm().FindMin(7,8,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new FibonacciAlgorithm().FindMin(7,8,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new ParabolasAlgorithm().FindMin(7,8,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new BrentAlgorithm().FindMin(7,8,0.0001, F));
            PrintSeparator();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Searching minimum for interval a = 13, b = 14, epsylon = 0.0001");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new BisectionAlgorithm().FindMin(13,14,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new GoldenRatioAlgorithm().FindMin(13,14,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new FibonacciAlgorithm().FindMin(13,14,0.0001, F));
            PrintSeparator(); 
            Console.WriteLine(new ParabolasAlgorithm().FindMin(10,11,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new BrentAlgorithm().FindMin(13,14,0.0001, F));
            PrintSeparator();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Searching minimum for interval a = 20, b = 21, epsylon = 0.0001");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new BisectionAlgorithm().FindMin(20,21,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new GoldenRatioAlgorithm().FindMin(20,21,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new FibonacciAlgorithm().FindMin(20,21,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new ParabolasAlgorithm().FindMin(17,18,0.0001, F));
            PrintSeparator();
            Console.WriteLine(new BrentAlgorithm().FindMin(20,21,0.0001, F));
            PrintSeparator();
        }
        
        private static double F(double x)
        {
            return Math.Log(Math.Pow(x, 2)) + 1 - Math.Sin(x);
        }
        private static void PrintSeparator()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

    }
}