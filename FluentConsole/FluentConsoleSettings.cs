using System;

namespace FluentConsole.Library
{
    /// <summary>
    /// Optionial configuration for FluentConsole
    /// </summary>
    public class FluentConsoleSettings
    {
        /// <summary>
        /// Gets or sets a value indicating how long lines of text should be displayed in the console window.
        /// </summary>
        public static LineWrapOption LineWrapOption { get; set; } = LineWrapOption.Auto;

        /// <summary>
        /// Gets or sets the line width used for wrapping long lines of text. Note: This value is ignored
        /// unless 'LineWrapOption' is set to 'Manual'. The default width is the value of the 
        /// 'Console.BufferWidth' property.
        /// </summary>
        public static int LineWrapWidth { get; set; } = ConsoleWrapper.BufferWidth;

        /// <summary>
        /// Gets or sets the delimter used when wrapping long lines of text. The default is a space character. Note: This value is ignored if 
        /// 'LineWrapOption' is set to 'Off'.
        /// </summary>
        public static char WordDelimiter { get; set; } = ' ';
    }
}