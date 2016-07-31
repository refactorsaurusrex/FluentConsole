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
            var builder = new StringBuilder();
            var offset = 0;
            var lineIndex = 0;

            while (true)
            {
                var skip = lineIndex++ * width - offset;
                var line = text.Skip(skip).Take(width).ToList();
                
                if (line.Count < width)
                {
                    builder.Append(line.ToArray());
                    break;
                }

                var index = line.LastIndexOf(' ');
                offset += line.Count - index - 1;
                builder.Append(line.Take(index).ToArray());
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
