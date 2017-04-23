using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentConsole.Library.ConsoleWrapper;

namespace FluentConsole.Library.V2
{
    public static class V2Extensions
    {
        // Todo: let user set up default formatting via FluentConsoleSettings

        public static IFluentConsoleReader WriteLine(this object value, int lineBreaks = 0)
        {
            ConsoleWrapper.WriteLine(value);

            for (var i = 0; i < lineBreaks; i++)
                NewLine();

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
