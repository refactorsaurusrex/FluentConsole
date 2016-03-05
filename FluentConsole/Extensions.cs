using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rawr.FluentConsole
{
    public static class Extensions
    {
        public static void WriteLine(this object value, int lineBreaks = 0)
        {
            Console.WriteLine(value);

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();
        }

        public static void WriteLineWait(this object value, int lineBreaks = 0)
        {
            Console.WriteLine(value);

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();

            Console.Read();
        }

        public static void WriteLine(this object value, ConsoleColor color, int lineBreaks = 0)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();
        }

        public static void WriteLineWait(this object value, ConsoleColor color, int lineBreaks = 0)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();

            Console.Read();
        }
    }
}
