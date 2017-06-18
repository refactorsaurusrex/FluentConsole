using System;
using System.Linq;
using System.Text;

namespace FluentConsole.Library.V2
{
    class FluentConsoleReader : IFluentConsoleReader
    {
        static readonly Lazy<FluentConsoleReader> instance = new Lazy<FluentConsoleReader>(() => new FluentConsoleReader());

        FluentConsoleReader() { }

        public static FluentConsoleReader Instance => instance.Value;

        public string ReadUntilAny(bool intercept = false)
        {
            return ConsoleWrapper.ReadKey(intercept).ToString();
        }

        public string ReadUntil(params ConsoleKey[] keys)
        {
            return ReadUntilCore(false, keys);
        }

        public string ReadUntil(bool intercept, params ConsoleKey[] keys)
        {
            return ReadUntilCore(intercept, keys);
        }

        string ReadUntilCore(bool intercept, params ConsoleKey[] keys)
        {
            var builder = new StringBuilder();

            while (true)
            {
                var key = ConsoleWrapper.ReadKey(intercept).Key;

                if (keys.Contains(key))
                    break;

                builder.Append(key);
            }

            return builder.ToString();
        }
    }
}