using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFunctions
{
    public class DataInput
    {
        public static T EnterValue<T>(string message)
        {
            var value = default(T);
            bool ok = true;

            do
            {
                try
                {
                    Console.Write(message + " ");
                    var s = Console.ReadLine();
                    value = (T)((IConvertible)s).ToType(typeof(T), new CultureInfo("en-en"));
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("The entered value is cannot be converted to type: {0}. Try again",typeof(T).ToString());
                    ok = false;
                }
            }
            while(!ok);

            return value;
        }
    }
}
