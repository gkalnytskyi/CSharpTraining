using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("App for replacing letters in files");
                Console.WriteLine("Usage:");
                Console.WriteLine("LetterReplacer.exe <source file> <destination file>");
                return;
            }

            string source = args[0];
            string destination = args[1];

            if (!File.Exists(source))
            {
                Console.WriteLine("The source file does not exist. Aborting execution.");
                return;
            }

            if (File.Exists(destination))
            {
                Console.Write("The destination file exists. Do you want to overwrite it? (Y/N)?");
                if (!Console.ReadLine().ToUpper().Equals("Y")) { return; }
            }

            try
            {
                File.WriteAllLines(destination, Replace(source));
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("Destination path is invalid");
            }
        }

        private static IEnumerable<string> Replace(string source)
        {
            LinkedList<string> stringList = new LinkedList<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string line in File.ReadLines(source))
            {
                sb.Clear();
                foreach (char letter in line)
                {
                    switch (letter)
                    {
                        case 'a':
                            sb.Append('b');
                            break;
                        case 'b':
                            sb.Append('c');
                            break;
                        case 'c':
                            sb.Append('a');
                            break;
                        default:
                            sb.Append(letter);
                            break;
                    }
                }
                stringList.AddLast(sb.ToString());
            }
            return stringList;
        }
    }
}
