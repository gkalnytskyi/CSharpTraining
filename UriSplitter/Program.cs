using System;
using System.Collections.Generic;
using System.Text;

namespace UriSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex: http://skydrive.live.com/some/long/path?version=1&id=123
            if (args.Length != 1)
            {
                Console.WriteLine("URI splitting");
                Console.WriteLine("Usage");
                Console.WriteLine("UriSplitter <valid uri>");
                return;
            }

            var addr = WebAddress.Parse(args[0]);

            Console.Write(addr.ToString());
            Console.ReadLine();
        }

        private class WebAddress
        {
            public string Protocol;
            public string Host;
            public string Domain;
            public string RelativePath;
            public Dictionary<string,string> Query;

            private WebAddress()
            {
                Query = new Dictionary<string,string>();
            }

            public static WebAddress Parse(string url)
            {   
                const string hostDomainSep = "://";
                const char domainRelativePathSep = '/';
                const char relativePathQuerySep = '?';
                const char queryItemsSep = '&';
                const char queryItemNameValueSep = '=';

                WebAddress addr = new WebAddress();

                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentException("Parsed URL cannot be null, empty, or contain only whitespace");
                }

                url = url.Trim();

                var t = url.Split(new[] { hostDomainSep }, StringSplitOptions.RemoveEmptyEntries);

                switch (t.Length)
                {
                    case 1: break;
                    case 2:
                        addr.Protocol = t[0];
                        url = t[1];
                        break;
                    default:
                        throw new ArgumentException("Invalid URL. URL contains sequence '://' more than one time");
                }

                t = url.Split(new[] { relativePathQuerySep }, StringSplitOptions.RemoveEmptyEntries);
                string query = null;

                switch (t.Length)
                {
                    case 1:
                        break;
                    case 2:
                        url = t[0];
                        query = t[1];
                        break;
                    default:
                        throw new ArgumentException("URL should not contain more than one '?' symbol");
                }

                t = url.Split(new[] { domainRelativePathSep }, 2);
                addr.Domain = t[0];
                if (t.Length == 2 && string.IsNullOrWhiteSpace(t[1]))
                {
                    throw new ArgumentException("Relative path could not be empty");
                }
                if (t.Length == 2)
                {
                    addr.RelativePath = t[1];
                }

                if (!string.IsNullOrEmpty(query))
                {
                    var queryItems = query.Split(new[] { queryItemsSep }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var queryItem in queryItems)
                    {
                        t = queryItem.Split(new[] { queryItemNameValueSep }, StringSplitOptions.RemoveEmptyEntries);
                        if (t.Length != 2)
                        {
                            throw new ArgumentException("The format of Web query is invalid");
                        }
                        addr.Query[t[0]] = t[1];
                    }
                }

                return addr;
            }

            public override string ToString()
            {
                const string notSpecified = "Not Specified";
                if (string.IsNullOrEmpty(Domain))
                {
                    throw new ApplicationException("Domain missing");
                }

                var sb = new StringBuilder();

                sb.AppendLine("Protocol = " + ((!string.IsNullOrEmpty(Protocol)) ? Protocol : notSpecified));
                sb.AppendLine("Domain = " + Domain);
                sb.AppendLine("Relative path = " + ((!string.IsNullOrEmpty(RelativePath)) ? RelativePath : notSpecified));
                if (Query.Count != 0)
                {
                    sb.AppendLine("Query string:");
                    foreach (var item in Query)
                    {
                        sb.AppendLine("\t" + item.Key + " = " + item.Value);
                    }
                }
                else
                {
                    sb.AppendLine("Query string: " + notSpecified);
                }

                return sb.ToString();
            }
        }
    }
}
