using System;
using System.Collections.Generic;
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
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;
            FluentConsoleSettings.LineWrapWidth = 50;

            "This is a really long string, longer than the default width of the Console window buffer. With any luck, this will be displayed as expected!".WriteLineWait();
        }
    }
}
