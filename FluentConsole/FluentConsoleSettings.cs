using System;

namespace FluentConsole.Library
{
    public class FluentConsoleSettings
    {
        static FluentConsoleSettings()
        {
            LineWrapWidth = Console.BufferWidth;
        }

        public static LineWrapOption LineWrapOption { get; set; }
        public static int LineWrapWidth { get; set; }
    }
}