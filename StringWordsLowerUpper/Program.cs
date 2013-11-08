using System;

namespace StringWordsLowerUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the sentence, and hit Enter.");
            string str = Console.ReadLine();
            string[] strList = str.Trim().
                                   Split(new char[] { ' ', '\t', '\n' },
                                         StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strList.Length; ++i)
            {
                if (i % 2 == 0)
                    Console.WriteLine(strList[i].ToLower());
                else
                    Console.WriteLine(strList[i].ToUpper());
            }
            Console.ReadLine();
        }
    }
}
