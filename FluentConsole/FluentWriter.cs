using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace FluentConsole.Library
{
    class FluentWriter
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

        static string LineWrap(string text, int width)
        {
            var lineCount = (int)Ceiling((double)text.Length / width);
            var builder = new StringBuilder();
            var offset = 0;

            for (var i = 0; i < lineCount; i++)
            {
                var skip = i * width - offset;
                var line = text.Skip(skip).Take(width).ToList();
                
                if (line.Count < width)
                {
                    builder.Append(line.ToArray());
                    continue; // continue vs break here: totally arbitrary because either way we're on the final iteration
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
