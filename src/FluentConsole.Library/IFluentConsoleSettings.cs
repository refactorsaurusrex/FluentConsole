namespace FluentConsole.Library
{
    public interface IFluentConsoleSettings
    {
        /// <summary>
        /// Gets or sets a value indicating how long lines of text should be displayed in the console window.
        /// </summary>
        LineWrapOption LineWrapOption { get; set; }

        /// <summary>
        /// Gets or sets the line width used for wrapping long lines of text. Note: This value is ignored
        /// unless 'LineWrapOption' is set to 'Manual'. A null value results in the value of Console.BufferWidth 
        /// being used.
        /// </summary>
        int? LineWrapWidth { get; set; }

        /// <summary>
        /// Gets or sets the delimter used when wrapping long lines of text. The default is a space character. Note: This value is ignored if 
        /// 'LineWrapOption' is set to 'Off'.
        /// </summary>
        char WordDelimiter { get; set; }
    }
}