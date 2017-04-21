using System;

namespace FluentConsole.Library.V2
{
    public interface IFluentConsole
    {
        IFluentConsole Intercept();
        IFluentConsoleReader WaitAny();
        IFluentConsoleReader WaitFor(params ConsoleKey[] keys);
    }
}