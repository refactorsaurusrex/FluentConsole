using System;

namespace FluentConsole.Library.V2
{
    public interface IFluentConsoleReader
    {
        string ReadUntilAny(bool intercept = false);
        string ReadUntil(params ConsoleKey[] keys);
        string ReadUntil(bool intercept, params ConsoleKey[] keys);
    }
}