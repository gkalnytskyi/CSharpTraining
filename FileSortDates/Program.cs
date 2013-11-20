using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace FileSortDates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("App for sorting dates in a file");
                Console.WriteLine("Usage:");
                Console.WriteLine("FileSortDates.exe <source file> <destination file>");
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

            string[] lines = File.ReadAllLines(source);
            List<DateTime> dates = new List<DateTime>();
            foreach (var line in lines)
            {
                DateTime d;
                try
                {
                    d = DateTime.ParseExact(line, "dd_MM_yyyy HH-mm", CultureInfo.InvariantCulture);
                    dates.Add(d);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Parsing error in line: " + line + " Skipping.");
                }
            }
            dates.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (var date in dates)
            {
                sb.AppendLine(date.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            File.WriteAllText(destination, sb.ToString());
            Console.WriteLine("Done!");
#if DEBUG
            Console.ReadLine();
#endif
        }
    }
}
