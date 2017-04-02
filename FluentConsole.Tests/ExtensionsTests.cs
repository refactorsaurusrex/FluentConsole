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

            FluentConsoleSettings.LineWrapOption = LineWrapOption.Auto;
            FluentConsoleSettings.WordDelimiter = ' ';
        }

        [Test, Order(1)]
        public void LineWrapSettings_ShouldDefaultToAuto()
        {
            FluentConsoleSettings.LineWrapOption.ShouldBe(LineWrapOption.Auto);
        }

        [Test]
        public void DefaultLineWrapping_ShouldResultInCorrectOutputString()
        {
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            result.ShouldBe($"This is a really long string, longer than the default width of the Console{n}window buffer, followed by two line breaks. With any luck, this will be{n}displayed as expected!{n}");
        }

        [Test]
        public void ManualLineWrapping_ShouldResultInCorrectOutputString()
        {
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Manual;
            FluentConsoleSettings.LineWrapWidth = 25;
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            result.ShouldBe($"This is a really long{n}string, longer than the{n}default width of the{n}Console window buffer,{n}followed by two line{n}breaks. With any luck,{n}this will be displayed as{n}expected!{n}");
        }

        [Test]
        public void Lines_ShouldNotBeWrapped_WhenLineWrappingIsOff()
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
        public void WriteLine_ShouldIncludeCorrectNumberOfExtraLineBreaks(int breaks)
        {
            "This is a test string".WriteLine(breaks);
            var result = output.ToString();

            var expected = new StringBuilder($"This is a test string{n}");
            for (var i = 0; i < breaks; i++)
                expected.Append($"{n}");

            var expectedString = expected.ToString();
            result.ShouldBe(expectedString);
        }

        [Test]
        public void WriteLine_ShouldNotFail_WhenWrappingLongBlocksOfTextWithoutDelimiters()
        {
            const string testString = "aaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            testString.WriteLine();
            var result = output.ToString();

            result.ShouldBe($"aaaaaa{n}aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa{n}");
        }

        [Test]
        public void WriteLine_ShouldWrapEachWord_WhenWidthIsSetToOne()
        {
            FluentConsoleSettings.LineWrapOption = LineWrapOption.Manual;
            FluentConsoleSettings.LineWrapWidth = 1;
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = output.ToString();
            var expected = $"This{n}is{n}a{n}really{n}long{n}string,{n}longer{n}than{n}the{n}default{n}width{n}of{n}the{n}Console{n}window{n}buffer,{n}followed{n}by{n}two{n}line{n}breaks.{n}With{n}any{n}luck,{n}this{n}will{n}be{n}displayed{n}as{n}expected!{n}";

            result.ShouldBe(expected);
        }

        [Test]
        public void LineWrapWidth_ShouldThrowException_WhenLessThanOne()
        {
            Assert.Throws<InvalidOperationException>(() => FluentConsoleSettings.LineWrapWidth = 0);
        }

        [Test]
        public void WriteLine_ShouldWriteEmptyStringPlusNewLine_WhenEmptyStringUsed()
        {
            "".WriteLine();
            var result = output.ToString();
            result.ShouldBe($"{n}");
        }
    }
}
