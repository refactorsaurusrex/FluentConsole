using System;
using System.Linq;
using System.Text;
using static FluentConsole.Library.ConsoleWrapper;

namespace FluentConsole.Library.V2
{
    class FluentConsole : IFluentConsole
    {
        bool intercept;

        public IFluentConsoleReader WaitAny()
        {
            var keyInfo = ReadKey();
            return new FluentConsoleReader(keyInfo.Key.ToString());
        }

        public IFluentConsoleReader WaitFor(params ConsoleKey[] keys)
        {
            var builder = new StringBuilder();

            while (true)
            {
                var key = ReadKey(intercept).Key;

                if (keys.Contains(key))
                    break;

                builder.Append(key);
            }

            return new FluentConsoleReader(builder.ToString());
        }

        public IFluentConsole Intercept()
        {
            intercept = true;
            return this;
        }
    }
}