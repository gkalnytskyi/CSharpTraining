using System;

namespace ArrayReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that reverses elements in the array");
            int l = EnterInt("Please enter the lenght of the array: ");

            double[] arr = new double[l];

            for (int i = 0; i < l; ++i)
            {
                arr[i] = EnterDouble("Please enter number " + i + ": ");
            }

            Console.WriteLine("Entered array:");
            PrintArray(arr);

            // Reversing array
            l = arr.Length;
            for (int i = 0; i < (l / 2); i++)
            {
                double t = arr[i];
                arr[i] = arr[l - i - 1];
                arr[l - i - 1] = t;
            }

            Console.WriteLine("Reversed array:");
            PrintArray(arr);
            Console.ReadLine();
        }

        private static double EnterDouble(string message)
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

        private static int EnterInt(string message)
        {
            int i = 0;
            bool ok = true;
            do
            {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out i);
                ok = ok && (i > 0);
                if (!ok)
                {
                    Console.WriteLine("The entered value is not a positive integer number. Try again");
                }
            }
            while (!ok);
            return i;
        }

        private static void PrintArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
