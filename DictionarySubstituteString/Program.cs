using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DictionarySubstituteString
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide the name of mapping file only");
                Console.WriteLine("Usage");
                Console.WriteLine("DictionarySubstituteString.exe <filepath>");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Please provide the valid path to mapping file.");
                return;
            }

            var dict = FormDictionary(File.ReadAllLines(args[0]));

            Console.WriteLine("Please enter string:");
            var s = Console.ReadLine();

            Console.WriteLine(ConvertString(s, dict));
#if DEBUG
            Console.ReadLine();
#endif
        }

        static string ConvertString(string s, Dictionary<char, char> dict)
        {
            var sb = new StringBuilder();

            foreach (var letter in s)
            {
                char c;
                if (dict.TryGetValue(letter, out c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }

        static Dictionary<char, char> FormDictionary(string[] lines)
        {
            var dict = new Dictionary<char, char>();
            foreach (var line in lines)
            {
                var res = ParseLine(line);
                try
                {
                    dict.Add(res[0], res[1]);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException("Dictionary contains duplicate " + 
                                                "entries for mapping char '" + res[0] + "'", ex);
                }
            }

            return dict;
        }
        
        static char[] ParseLine(string line)
        {
            var t = line.Split(new []{ "->" },StringSplitOptions.RemoveEmptyEntries);
            if (t.Length != 2)
            {
                throw new ArgumentException("Parsing line: '" + line + "'" + Environment.NewLine +
                                            "Parsed line has invalid format. It should contain only char to char mapping");
            }

            string key = t[0].Trim();
            string value = t[1].Trim();

            if (key.Length != 1 || value.Length != 1)
            {
                throw new ArgumentException("Invalid mapping: '" + key + "' -> '" + value + "'"
                    + Environment.NewLine + "Char to char mapping is only allowed");
            }

            return new char[]{key[0], value[0]};
        }
    }
}
