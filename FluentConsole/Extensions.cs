using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace FluentConsole.Library
{
    /// <summary>
    /// Fluent interface for console applications
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="lineBreaks">The number of *additional* line breaks to include after the specified value.</param>
        public static void WriteLine(this object value, int lineBreaks = 0)
        {
            Console.WriteLine(value);

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="lineBreaks">The number of *additional* line breaks to include after the specified value.</param>
        /// <returns>The key entered while waiting.</returns>
        public static ConsoleKeyInfo WriteLineWait(this object value, int lineBreaks = 0)
        {
            Console.WriteLine(value);

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();

            return ReadKey();
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="color">The color of the text displayed.</param>
        /// <param name="lineBreaks">The number of *additional* line breaks to include after the specified value.</param>
        public static void WriteLine(this object value, ConsoleColor color, int lineBreaks = 0)
        {
            ForegroundColor = color;
            Console.WriteLine(value);
            ResetColor();

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="color">The color of the text displayed.</param>
        /// <param name="lineBreaks">The number of *additional* line breaks to include after the specified value.</param>
        /// <returns>The key entered while waiting.</returns>
        public static void WriteLineWait(this object value, ConsoleColor color, int lineBreaks = 0)
        {
            ForegroundColor = color;
            Console.WriteLine(value);
            ResetColor();

            for (var i = 1; i < lineBreaks; i++)
                Console.WriteLine();

            ReadKey();
        }

        static string NormalizeWidth(string text)
        {
            if (text.Length <= BufferWidth)
                return text;

            var lineCount = (int)Ceiling((double)text.Length / BufferWidth);
            var builder = new StringBuilder(text.Length + lineCount);

            for (var i = 0; i <= lineCount; i++)
            {
                var line = text.Skip(0 * BufferHeight).Take(BufferHeight).ToList();
                var index = line.LastIndexOf(' ');
                line.InsertRange(index, new[] {'\r','\n'});
                builder.Append(line);
            }

            return builder.ToString();
        }
    }
}
