using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentConsole.Library.V2
{
    public static class FluentConsoleExtensions
    {
        public static IFluentConsoleReader WriteLine(this object value, int lineBreaks = 0)
        {
            ConsoleWrapper.WriteLine(value);

            for (var i = 0; i < lineBreaks; i++)
                ConsoleWrapper.NewLine();

            return FluentConsoleReader.Instance;
        }

        public static IFluentConsoleReader WriteLine(this object value, ConsoleColor foreColor, int lineBreaks = 0)
        {
            return FluentConsoleReader.Instance;
        }

        public static IFluentConsoleReader WriteLine(this object value, ConsoleColor foreColor, ConsoleColor backColor, int lineBreaks = 0)
        {
            return FluentConsoleReader.Instance;
        }

        public static IFluentConsoleReader WriteLine(this object value, WriteOptions options)
        {
            return FluentConsoleReader.Instance;
        }
    }
}
