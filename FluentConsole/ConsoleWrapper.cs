using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace FluentConsole.Library
{
    class ConsoleWrapper
    {
        public static void NewLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(object value)
        {
            if (FluentConsoleSettings.LineWrapOption == LineWrapOption.Off)
            {
                Console.WriteLine(value);
                return;
            }

            var bufferWidth = FluentConsoleSettings.LineWrapOption == LineWrapOption.Auto ? BufferWidth : FluentConsoleSettings.LineWrapWidth;
            var valueText = value.ToString();

            if (valueText.Length <= bufferWidth)
            {
                Console.WriteLine(value);
                return;
            }

            var wrappedText = LineWrap(valueText, bufferWidth);
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

            set { Console.BufferWidth = value; }
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public static ConsoleColor ForegroundColor
        {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }

        public static ConsoleColor BackgroundColor
        {
            get { return Console.BackgroundColor; }
            set { Console.BackgroundColor = value; }
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        static string LineWrap(string text, int width)
        {
            var delimiter = FluentConsoleSettings.WordDelimiter;
            var words = text.Split(delimiter);
            var allLines = words.Skip(1).Aggregate(words.Take(1).ToList(), (lines, word) =>
            {
                if (lines.Last().Length + word.Length >= width)
                    lines.Add(word);
                else
                    lines[lines.Count - 1] += delimiter + word;
                return lines;
            });

            return string.Join(Environment.NewLine, allLines.ToArray());
        }
    }
}
