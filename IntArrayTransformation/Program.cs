using System;

namespace IntArrayTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Integer Transformations Program");
            int l = EnterPInt("Enter the length of an array: ");

            int[] arr = new int[l];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = EnterInt("Enter element " + i + ": ");
            }

            // Transformation
            int[] transformedArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                int t = TransformationRule(arr[i]);

                transformedArray[i] = t;
            }

            Console.WriteLine("Entered array:");
            PrintArray(arr);
            Console.WriteLine("Transformed array:");
            PrintArray(transformedArray);
            Console.ReadLine();
        }

        private static int TransformationRule(int i)
        {
            switch (i)
            {
                case 0: return 1;
                case 1: return 42;
                case 2: return -42;
                case 3: return 0;
                default: return Math.Abs(i - 3) + 1;
            }
        }

        private static int EnterPInt(string message)
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

        private static int EnterInt(string message)
        {
            int i = 0;
            bool ok = true;
            do
            {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out i);
                if (!ok)
                {
                    Console.WriteLine("The entered value is not an integer number. Try again");
                }
            }
            while (!ok);
            return i;
        }

        private static void PrintArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
