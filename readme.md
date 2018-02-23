# Fluent Console Library

[![Build status](https://ci.appveyor.com/api/projects/status/d1g6pl6x4uuyf9hl/branch/master?svg=true)](https://ci.appveyor.com/project/refactorsaurusrex/fluentconsole/branch/master)

Fluent Console Library is a single class of extension methods that simplify writing messages to the console window.

## Usage

We're used to writing console messages like this:

```csharp
Console.WriteLine("This is a line of text!");
Console.WriteLine(); // Add some spacing
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("This is a RED line of text!");
Console.ResetColor();
Console.WriteLine("This is another WHITE line of text!");
Console.ReadKey(); // Wait for input
```

Personally, I find it more sensible and less tedious to write it like this:

```csharp
"This is a line of text!".WriteLine(lineBreaks: 2);
"This is a RED line of text!".WriteLine(ConsoleColor.Red);
"This is another WHITE line of text!".WriteLineWait();
```

Just add `using FluentConsole.Library;` to your namespace import statements and you're ready to go!

## Automatic Line Wrapping

By default, FluentConsole will automatically wrap long lines of text to fit readably in the console window. This is done by strategically inserting line breaks in between words at end of each line. The default line length is the current width of the console window, but this can be changed to any width you desire or disabled completely, if you choose. Refer to the `FluentConsoleSettings` type for more information.

**Taken from the 'FluentConsole.Demo' Project**

![Demo](/Images/FluentConsoleDemo.gif)

## Installation

Updates to this repo are continuously packaged and [deployed to nuget](https://www.nuget.org/packages/FluentConsole.Library/), so whatever code you see here is already available in the wild. Just open the Nuget package manager in Visual Studio and search for 'fluentconsole'. **Note:** There is another, similarly named package available, so make sure you're installing the one you want.

![Nuget Package Manager Search Result](/Images/NuGetPackageManagerSearchResult.png)

To install from the Package Manager Console, run: `Install-Package FluentConsole.Library`

## Contributions and Maintenance

I only update this library on an **as-needed basis**. That means, if I happen to not be writing C# console applications for an extended period of time, I will probably also not be updating this library much. So if you find it useful - but lacking in some specific way - please consider contributing to the project yourself. I just ask that you first review the [contributing guidelines](/CONTRIBUTING.MD) before you begin making changes. Alternatively, you can fork this repo and do whatever strikes your fancy. :)

## Found a bug?

Something not working as you'd expect? Create an issue.

## License

[The MIT License (MIT)](/license.md)
