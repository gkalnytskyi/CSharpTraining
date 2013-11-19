using System;

namespace CountSundaysXX
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate;
            DateTime endDate;

            //startDate = new DateTime(1901, 1, 1);
            //endDate = new DateTime(2001, 1, 1);

            endDate = DateTime.Now;
            startDate = endDate.AddDays(-7);

            Console.WriteLine(CountWithFor(startDate, endDate));
            Console.WriteLine(CountByDividing(startDate, endDate));
            Console.ReadLine();
        }

        private static int CountWithFor(DateTime startDate, DateTime endDate)
        {
            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(1);
            }

            int count = 0;
            DateTime date = startDate;
            while (date < endDate)
            {
                ++count;
                date = date.AddDays(7);
            }
            return count;
        }

        private static int CountByDividing(DateTime startDate, DateTime endDate)
        {
            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(1);
            }

            if (endDate < startDate)
            {
                return 0;
            }
            return (endDate - startDate).Days / 7 + 1;
        }
    }
}
