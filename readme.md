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

## Installation
Updates to this repo are continuously packaged and [deployed to nuget](https://www.nuget.org/packages/FluentConsole.Library/), so whatever code you see here is already available in the wild. Just open the Nuget package manager in Visual Studio and search for 'fluentconsole'. **Note:** There is another, similarly named package available, so make sure you're installing the one you want.

![Nuget Package Manager Search Result](https://raw.githubusercontent.com/refactorsaurusrex/FluentConsole/master/Images/NuGetPackageManagerSearchResult.png)

To install from the Package Manager Console, type: `Install-Package FluentConsole.Library`

## Got an idea for additional functionality?
Create an issue and **let's discuss it!** At the time of this writing, there are only four methods in this library, but I fully expect more to be added over time as the need arises. I'm also totally open to outside suggestions and pull requests.

Alternatively, you can fork this repo and do whatever strikes your fancy. :)

## Found a bug?
Something not working as you'd expect? Create an issue.

## License
[The MIT License (MIT)](https://github.com/refactorsaurusrex/FluentConsole/blob/MinorUpdates/license.md)
