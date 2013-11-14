using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CountLetersInText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The app for counting letters in words that begin with capital letter.");
            if (args.Length != 1)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("CountLetersInText.exe <file path>");
                return;
            }

            IEnumerable<string> fileLines;
            try
            {
                int count = LetterCounting(File.ReadLines(args[0]));

                Console.WriteLine("The number of charachters is {0}", count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Path is invalid");
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static int LetterCounting(IEnumerable<string> fileLines)
        {
            int count = 0;

            foreach (var line in fileLines)
            {
                string[] words = line.Split(new char[] { ' ', '\t', '.', '?', ',', '!', ':' },
                                            StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (char.IsUpper(word[0]))
                    {
                        count += word.Length;
                    }
                }
            }
            return count;
        }
    }
}
