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
    }
}