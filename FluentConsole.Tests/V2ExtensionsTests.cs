using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentConsole.Library.V2;

namespace FluentConsole.Tests
{
    [TestFixture]
    public class V2ExtensionsTests
    {
        public void Blah()
        {
            IFluentConsole fluentConsole = "this is a test".WriteLine();
            IFluentConsole fluentConsoleIntercepter = fluentConsole.Intercept();

            IFluentConsoleReader reader1 = fluentConsoleIntercepter.WaitAny();
            string reader1Text = reader1.Text;

            IFluentConsoleReader reader = fluentConsole.WaitAny();
            string readerText = reader.Text;

            IFluentConsoleReader waitAnyResult = "this is a test".WriteLine().WaitAny();

            IFluentConsoleReader intercept = "this is a test".WriteLine().WaitFor(ConsoleKey.A, ConsoleKey.Escape);
            string text = intercept.Text;

            IFluentConsoleReader waitHandle = "this is a test".WriteLine().WaitFor(ConsoleKey.A, ConsoleKey.Escape);
            string text1 = waitHandle.Text;
        }
    }
}
