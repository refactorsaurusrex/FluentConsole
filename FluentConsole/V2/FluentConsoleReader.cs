using System;

namespace FluentConsole.Library.V2
{
    class FluentConsoleReader : IFluentConsoleReader
    {
        internal FluentConsoleReader(string text = "")
        {
            Text = text;
        }

        public string Text { get; private set; }

        public IFluentConsoleReader Intercept()
        {
            Console.ReadKey(true);
            Text = "some text";
            return this;
        }
    }

    class FluentConsoleInterceptReader : IFluentConsoleReader
    {
        internal FluentConsoleInterceptReader(string text = "")
        {
            Text = text;
        }

        public string Text { get; private set; }

        public IFluentConsoleReader Intercept()
        {
            Console.ReadKey(true);
            Text = "some text";
            return this;
        }
    }
}