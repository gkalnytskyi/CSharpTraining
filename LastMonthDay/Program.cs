using System;
using System.Globalization;
using System.Text;

namespace LastMonthDay
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Usage();
            }

            DateTime date = default(DateTime);
            try
            {
                date = DateTime.ParseExact(args[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                Usage();
            }

            DateTime monthEnd = default(DateTime);
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    monthEnd = new DateTime(date.Year, date.Month, 31);
                    break;
                case 2:
                    var isLeap = (date.Year % 4 == 0 && date.Year % 100 != 0) || (date.Year % 400 == 0);
                    monthEnd = new DateTime(date.Year, date.Month, (!isLeap) ? 28 : 29);
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    monthEnd = new DateTime(date.Year, date.Month, 30);
                    break;
            }

            Console.WriteLine("Last date of the month " + monthEnd.ToString("yyyy-MM-dd"));
            Console.WriteLine("Date of the week: " + monthEnd.DayOfWeek);
            Console.ReadLine();
        }

        private static void Usage()
        {
            Console.WriteLine("LastMonthDay.exe <date>");
            Console.WriteLine("date format yyyy-mm-dd");
        }
    }
}
