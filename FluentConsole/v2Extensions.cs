using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentConsole.Library.V2
{
    public interface IFluentConsoleLine
    {
        IFluentConsoleInput WaitAny();

        IFluentConsoleInput WaitSpecific(params ConsoleKey[] keys);
    }

    //public interface IFluentConsoleWaitHandle
    //{
    //    IFluentConsoleInput Intercept();
    //    string Text { get; }
    //}

    public interface IFluentConsoleInput
    {
        string Text { get; }
        IFluentConsoleInput Intercept();
    }

    class FluentConsoleInput : IFluentConsoleInput
    {
        internal FluentConsoleInput(string text = "")
        {
            Text = text;
        }

        public string Text { get; private set; }

        public IFluentConsoleInput Intercept()
        {
            Console.ReadKey(true);
            Text = "some text";
            return this;
        }
    }

    //class FluentConsoleWaitHandle : IFluentConsoleWaitHandle
    //{
    //    public FluentConsoleWaitHandle(string text = "")
    //    {
    //        Text = text;
    //    }

    //    public IFluentConsoleInput Intercept()
    //    {
    //        return new FluentConsoleInput("some text");
    //    }

    //    public string Text { get; }
    //}

    class FluentConsoleLine : IFluentConsoleLine
    {
        public IFluentConsoleInput WaitAny()
        {
            return new FluentConsoleInput();
        }

        public IFluentConsoleInput WaitSpecific(params ConsoleKey[] keys)
        {
            return new FluentConsoleInput();
        }
    } 

    public static class V2Extensions
    {
        public static IFluentConsoleLine WriteLine(this object value)
        {
            return new FluentConsoleLine();
        }
    }
}
