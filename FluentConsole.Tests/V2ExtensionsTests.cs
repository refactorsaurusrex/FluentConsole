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
            IFluentConsoleReader fluentConsoleReader = "this is a test".WriteLine();

            string reader = fluentConsoleReader.ReadUntilAny();

            string waitAnyResult = "this is a test".WriteLine().ReadUntilAny();

            string intercept = "this is a test".WriteLine().ReadUntil(ConsoleKey.A, ConsoleKey.Escape);

            string waitHandle = "this is a test".WriteLine().ReadUntil(ConsoleKey.A, ConsoleKey.Escape);
        }
    }
}
