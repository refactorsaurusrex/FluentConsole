using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentConsole.Library;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "Press any key to continue...".WriteLineWait();

            $"You pressed the '{key.Key}' key!".WriteLine(1);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Manual;
            FluentConsoleSettings.LineWrapWidth = 25;

            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;

            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Off;

            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;

            "This is a much shorter string, with zero line breaks.".WriteLine();

            "This is a green string with one line break.".WriteLine(ConsoleColor.Green, 1);

            "A red string, with zero breaks, and waits after printing".WriteLineWait(ConsoleColor.Red);

            "This is a much shorter string, with zero line breaks.".WriteLineWait();
        }
    }
}
