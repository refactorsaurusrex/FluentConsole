using System;

namespace FluentConsole.Library
{
    /// <summary>
    /// Optional configuration for FluentConsole
    /// </summary>
    public class FluentConsoleSettings  : IFluentConsoleSettings
    {
        private int? _lineWrapWidth;

        /// <inheritdoc />
        public LineWrapOption LineWrapOption { get; set; } = LineWrapOption.Auto;

        /// <inheritdoc />
        public int? LineWrapWidth
        {
            get => _lineWrapWidth;

            set
            {
                if (value.HasValue && value.Value < 1)
                    throw new InvalidOperationException("Value cannot be less than 1.");

                _lineWrapWidth = value;
            }
        }

        /// <inheritdoc />
        public char WordDelimiter { get; set; } = ' ';
    }
}