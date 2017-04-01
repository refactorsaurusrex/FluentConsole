using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentConsole.Library;
using NUnit.Framework;
using Shouldly;

namespace FluentConsole.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        StringWriter output;
        readonly string n = Environment.NewLine;

        [SetUp]
        public void SetUp()
        {
            output = new StringWriter();
            Console.SetOut(output);
        }

        [TearDown]
        public void TearDown()
        {
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;
        }

        [Test, Order(1)]
        public void LineWrapSettingsShouldDefaultToAuto()
        {
            FluentConsoleSettings.LineWrapOption.ShouldBe(LineWrapOption.Auto);
        }

        [Test]
        public void DefaultLineWrappingShouldResultInCorrectOutputString()
        {
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            result.ShouldBe($"This is a really long string, longer than the default width of the Console{n}window buffer, followed by two line breaks. With any luck, this will be{n}displayed as expected!{n}");
        }

        [Test]
        public void ManualLineWrappingShouldResultInCorrectOutputString()
        {
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Manual;
            FluentConsoleSettings.LineWrapWidth = 25;
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            result.ShouldBe($"This is a really long{n}string, longer than the{n}default width of the{n}Console window buffer,{n}followed by two line{n}breaks. With any luck,{n}this will be displayed as{n}expected!{n}");
        }

        [Test]
        public void LinesShouldNotBeWrappedWhenLineWrappingIsOff()
        {
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Off;
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            
            result.ShouldBe($"This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!{n}");
        }

        [TestCase(5)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void WriteLineShouldIncludeCorrectNumberOfExtraLineBreaks(int breaks)
        {
            "This is a test string".WriteLine(breaks);
            var result = output.ToString();

            var expected = new StringBuilder($"This is a test string{n}");
            for (int i = 0; i < breaks; i++)
                expected.Append($"{n}");

            var expectedString = expected.ToString();
            result.ShouldBe(expectedString);
        }
    }
}
