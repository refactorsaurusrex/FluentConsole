using System;
using System.Linq;

namespace FluentConsole.Library
{
    internal class ConsoleWrapper
    {
        public static void NewLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(object value, IFluentConsoleSettings settings)
        {
            if (settings.LineWrapOption == LineWrapOption.Off)
            {
                Console.WriteLine(value);
                return;
            }

            var bufferWidth = BufferWidth;
            if (settings.LineWrapOption == LineWrapOption.Manual && settings.LineWrapWidth.HasValue)
            {
                bufferWidth = settings.LineWrapWidth.Value;
            }

            var valueText = value.ToString();

            if (valueText.Length <= bufferWidth)
            {
                Console.WriteLine(value);
                return;
            }

            var wrappedText = LineWrap(valueText, bufferWidth, settings);
            Console.WriteLine(wrappedText);
        }

        public static int BufferWidth
        {
            get
            {
                try
                {
                    return Console.BufferWidth;
                }
                catch (Exception)
                {
                    return 80;
                }
            }

            set => Console.BufferWidth = value;
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public static ConsoleColor ForegroundColor
        {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        public static ConsoleColor BackgroundColor
        {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        private static string LineWrap(string text, int width, IFluentConsoleSettings settings)
        {
            var delimiter = settings.WordDelimiter;
            var words = text.Split(delimiter);
            var allLines = words.Skip(1).Aggregate(words.Take(1).ToList(), (lines, word) =>
            {
                if (lines.Last().Length + word.Length >= width - 1) // Minus 1, to allow for newline char
                    lines.Add(word);
                else
                    lines[lines.Count - 1] += delimiter + word;
                return lines;
            });

            return string.Join(Environment.NewLine, allLines.ToArray());
        }
    }
}
