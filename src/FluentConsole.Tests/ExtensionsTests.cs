using System;
using System.IO;
using System.Text;
using FluentAssertions;
using FluentConsole.Library;
using Xunit;

namespace FluentConsole.Tests
{
    public class ExtensionsTests
    {
        private readonly StringWriter _output = new StringWriter();
        private readonly string _n = Environment.NewLine;

        public ExtensionsTests()
        {
            Console.SetOut(_output);
        }

        [Fact]
        public void Setting_ShouldHave_ReasonableDefaults()
        {
            var settings = new FluentConsoleSettings();
            settings.LineWrapOption.Should().Be(LineWrapOption.Auto);
            settings.LineWrapWidth.Should().Be(null);
            settings.WordDelimiter.Should().Be(' ');
        }

        [Fact]
        public void DefaultLineWrapping_ShouldResultInCorrectOutputString()
        {
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine();
            var result = _output.ToString();
            result.Should().Be($"This is a really long string, longer than the default width of the Console{_n}window buffer, followed by two line breaks. With any luck, this will be{_n}displayed as expected!{_n}");
        }

        [Fact]
        public void ManualLineWrapping_ShouldResultInCorrectOutputString()
        {
            var settings = new FluentConsoleSettings {LineWrapOption = LineWrapOption.Manual, LineWrapWidth = 25};
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(settings: settings);
            var result = _output.ToString();
            result.Should().Be($"This is a really long{_n}string, longer than the{_n}default width of the{_n}Console window buffer,{_n}followed by two line{_n}breaks. With any luck,{_n}this will be displayed{_n}as expected!{_n}");
        }

        [Fact]
        public void Lines_ShouldNotBeWrapped_WhenLineWrappingIsOff()
        {
            var settings = new FluentConsoleSettings { LineWrapOption = LineWrapOption.Off };
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(settings: settings);
            var result = _output.ToString();

            result.Should().Be($"This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!{_n}");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void WriteLine_ShouldIncludeCorrectNumberOfExtraLineBreaks(int breaks)
        {
            "This is a test string".WriteLine(breaks);
            var result = _output.ToString();

            var expected = new StringBuilder($"This is a test string{_n}");
            for (var i = 0; i < breaks; i++)
                expected.Append($"{_n}");

            var expectedString = expected.ToString();
            result.Should().Be(expectedString);
        }

        [Fact]
        public void WriteLine_ShouldNotFail_WhenWrappingLongBlocksOfTextWithoutDelimiters()
        {
            const string testString = "aaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            testString.WriteLine();
            var result = _output.ToString();

            result.Should().Be($"aaaaaa{_n}aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa{_n}");
        }

        [Fact]
        public void WriteLine_ShouldWrapEachWord_WhenWidthIsSetToOne()
        {
            var settings = new FluentConsoleSettings { LineWrapOption = LineWrapOption.Manual, LineWrapWidth = 1 };
            "This is a really long string, longer than the default width of the Console window buffer, followed by two line breaks. With any luck, this will be displayed as expected!".WriteLine(settings: settings);
            var result = _output.ToString();
            var expected = $"This{_n}is{_n}a{_n}really{_n}long{_n}string,{_n}longer{_n}than{_n}the{_n}default{_n}width{_n}of{_n}the{_n}Console{_n}window{_n}buffer,{_n}followed{_n}by{_n}two{_n}line{_n}breaks.{_n}With{_n}any{_n}luck,{_n}this{_n}will{_n}be{_n}displayed{_n}as{_n}expected!{_n}";

            result.Should().Be(expected);
        }

        [Fact]
        public void LineWrapWidth_ShouldThrowException_WhenLessThanOne()
        {
            var settings = new FluentConsoleSettings();
            Assert.Throws<InvalidOperationException>(() => settings.LineWrapWidth = 0);
        }

        [Fact]
        public void WriteLine_ShouldWriteEmptyStringPlusNewLine_WhenEmptyStringUsed()
        {
            "".WriteLine();
            var result = _output.ToString();
            result.Should().Be($"{_n}");
        }
    }
}
