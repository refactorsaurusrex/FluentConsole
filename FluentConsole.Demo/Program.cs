using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentConsole.Library;

namespace FluentConsole.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
 
        }

        public void RunV2Demo()
        {
            
        }

        public void RunV1Demo()
        {
#pragma warning disable 612
            var message = new WriteOptions { ForeColor = ConsoleColor.Yellow, LineBreaks = 1 };
            "".WriteLine();

            "Welcome to FluentConsole!".WriteLine(ConsoleColor.Red);
            "=========================".WriteLine(ConsoleColor.Red, 1);

            var key = "This is an example of 'WriteLineWait'. It's a wrapper around 'Console.ReadKey'. Press any key to continue...".WriteLineWait(message);

            $"You pressed the '{key.Key}' key! Next, I'll set the line wrap width to 25 pixels and write a long line of text. Press any key to continue...".WriteLineWait(message);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Manual;
            FluentConsoleSettings.LineWrapWidth = 25;

            const string longText = "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!";

            longText.WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;

            "Next, I'll turn line wrapping back to 'Auto', which means it will wrap using the current width of the console window.".WriteLineWait(message);

            longText.WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Off;

            "And now, I'll turn line wrapping off completely. Ready?".WriteLineWait(message);

            longText.WriteLine(2);

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;

            "The line above might look fine, or it might not. It depends on the width of your windows. Press any key for more examples...".WriteLineWait(message);

            "This is a much shorter string, with zero line breaks.".WriteLine();

            "This is a green string with one line break.".WriteLine(ConsoleColor.Green, 1);

            "This some text that is profoundly ugly.".WriteLine(ConsoleColor.Magenta, ConsoleColor.White, 2);

            "That's all for now!".WriteLine(message);
            "I only update this library on an as-needed basis. That means, if I happen to not be writing console apps for an extended period, I probably will also not be updating this library much. So if you find it useful - but lacking in some specific way - take a look at this repo's readme on GitHub for information on contributing!".WriteLineWait(ConsoleColor.Cyan);
#pragma warning restore 612
        }
    }
}
