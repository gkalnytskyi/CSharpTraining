using System;

namespace SumofMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            Console.WriteLine("First solution. The sum is: " + FindSum1(n));
            Console.WriteLine("Second solution. The sum is: " + FindSum2(n));
            Console.WriteLine("Third solution. The sum is: " + FindSum3(n));
            Console.ReadLine();
        }

        // calculates the sum of all multiples of 3 or 5 that are less than n
        static int FindSum1(int n)
        {
            int sum = 0;
            int i = 3;

            while (i < n)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;
                
                ++i;
            }

            return sum;
        }

        static int FindSum2(int n)
        {
            int sum = 0;

            int i = 3;
            while (i < n)
            {
                sum += i;
                i += 3;
            }

            i = 5;
            while (i < n)
            {
                if ( i % 3 != 0)
                    sum += i;
                i += 5;
            }

            return sum;
        }

        static int FindSum3(int n)
        {
            n--;
            int sum = 0;

            int div3 = n / 3;
            int div5 = n / 5;
            int div15 = n / 15;

            sum = (3 * div3 * (div3 + 1) + 5 * div5 * (div5 + 1) - 15 * div15 * (div15 + 1)) / 2;

            return sum;
        }
    }
}
