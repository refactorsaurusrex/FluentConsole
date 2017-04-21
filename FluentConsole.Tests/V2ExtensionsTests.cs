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
            "this is a test".WriteLine();

            IFluentConsoleInput waitAnyResult = "this is a test".WriteLine().WaitAny();

            IFluentConsoleInput intercept = "this is a test".WriteLine().WaitSpecific(ConsoleKey.A, ConsoleKey.Escape).Intercept();
            string text = intercept.Text;

            IFluentConsoleInput waitHandle = "this is a test".WriteLine().WaitSpecific(ConsoleKey.A, ConsoleKey.Escape);
            string text1 = waitHandle.Text;
        }
    }
}
