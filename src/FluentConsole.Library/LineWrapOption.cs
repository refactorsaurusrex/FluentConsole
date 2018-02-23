namespace FluentConsole.Library
{
    /// <summary>
    /// Values indicating how long lines of text should be displayed in the console window.
    /// </summary>
    public enum LineWrapOption
    {
        /// <summary>
        /// Automatically determine the maximum line length. This is determined by the 'Console.BufferWidth' property.
        /// </summary>
        Auto,
        /// <summary>
        /// Maximum line length is determined by a value explicitly set by the user. (Default is the value of 'Console.BufferWidth'.)
        /// </summary>
        Manual,
        /// <summary>
        /// Do not automatically wrap long lines of text.
        /// </summary>
        Off
    }
}