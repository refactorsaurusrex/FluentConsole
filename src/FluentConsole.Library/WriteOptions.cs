using System;

namespace FluentConsole.Library
{
    /// <summary>
    /// A collection of display options for use when writing to the console using the FluentConsole library.
    /// </summary>
    public class WriteOptions
    {
        /// <summary>
        /// The foreground color of the text displayed.
        /// </summary>
        public ConsoleColor ForeColor { get; set; } = ConsoleColor.White;

        /// <summary>
        /// The background color of the text displayed.
        /// </summary>
        public ConsoleColor BackColor { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// The number of *additional* line breaks to include after the specified value.
        /// </summary>
        public int LineBreaks { get; set; } = 0;
    }
}
