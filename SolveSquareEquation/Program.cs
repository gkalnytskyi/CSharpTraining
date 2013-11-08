using System;

namespace SolveSquareEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("The program for calculating roots of square equation.");
            Console.WriteLine("a x^2 + b x + c = 0");
            a = EnterNumber("Enter a: ");
            b = EnterNumber("Enter b: ");
            c = EnterNumber("Enter c: ");
            double aAbs = Math.Abs(a);
            double bAbs = Math.Abs(b);
            double cAbs = Math.Abs(c);

            Console.WriteLine(a + " x^2 + (" + b + ") x + (" + c + ") = 0");

            if (aAbs < double.Epsilon)
            {
                if (bAbs < double.Epsilon)
                {
                    if (cAbs < double.Epsilon)
                    {
                        Console.WriteLine("x can be any");
                    }
                    else
                    {
                        Console.WriteLine("No solution could be found");
                    }
                }
                else
                {
                    Console.WriteLine("x = {0}", -c / b);
                }
            }
            else
            {
                if (bAbs < double.Epsilon)
                {
                    if (a * c > 0)
                    {
                        Console.WriteLine("No solution exists for real numbers");
                    }
                    else
                    {
                        Console.WriteLine("x = {0}", Math.Sqrt(-c / a));
                    }
                }
                else
                {
                    if (cAbs < double.Epsilon)
                    {
                        Console.WriteLine("x_1 = {0}, x_2 = {1}", (double)0, -b / a);
                    }
                    else
                    {
                        double det = GetDeterminant(a, b, c);
                        if (det < 0)
                        {
                            Console.WriteLine("No solution exists for real numbers");
                        }
                        else if ( det < double.Epsilon)
                        {
                            Console.WriteLine("x_1 = x_2 = {0}", - b / (2*a));
                        }
                        else
                        {
                            double t = b + Math.Sqrt(det);
                            double x_1 = -t / (2 * a);
                            double x_2 = -2 * c / t;
                            Console.WriteLine("x_1 = {0}, x_2 = {1}", x_1, x_2);
                        }
                    }
                }
            }
            Console.ReadLine();
        }

        private static double EnterNumber(string message)
        {
            double f = 0;
            bool ok = true;
            do
            {
                Console.Write(message);
                ok = double.TryParse(Console.ReadLine(), out f);
                if (!ok)
                {
                    Console.WriteLine("The entered value is not a number. Try again");
                }
            }
            while (!ok);
            return f;
        }

        private static double GetDeterminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }
    }
}
