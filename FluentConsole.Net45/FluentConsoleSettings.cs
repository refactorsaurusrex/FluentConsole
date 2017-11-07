﻿using System;

namespace FluentConsole.Library
{
    /// <summary>
    /// Optional configuration for FluentConsole
    /// </summary>
    public class FluentConsoleSettings
    {
        private static int lineWrapWidth;

        public FluentConsoleSettings()
        {
            LineWrapWidth = ConsoleWrapper.BufferWidth;
        }

        /// <summary>
        /// Gets or sets a value indicating how long lines of text should be displayed in the console window.
        /// </summary>
        public static LineWrapOption LineWrapOption { get; set; } = LineWrapOption.Auto;

        /// <summary>
        /// Gets or sets the line width used for wrapping long lines of text. Note: This value is ignored
        /// unless 'LineWrapOption' is set to 'Manual'. The default width is the value of the 
        /// 'Console.BufferWidth' property.
        /// </summary>
        public static int LineWrapWidth
        {
            get { return lineWrapWidth; }

            set
            {
                if (value < 1)
                    throw new InvalidOperationException("Value cannot be less than 1.");

                lineWrapWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the delimiter used when wrapping long lines of text. The default is a space character. Note: This value is ignored if 
        /// 'LineWrapOption' is set to 'Off'.
        /// </summary>
        public static char WordDelimiter { get; set; } = ' ';
    }
}