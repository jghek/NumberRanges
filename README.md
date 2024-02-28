# NumberRanges

## Introduction
A simple library to manage and use integer number ranges like used on a printer: 2-10,12,15-.

## Prerequisites
This package targets .NET Standard 2.1, so it should work with most .NET platforms.

## Installation
Use NuGet to install the package. Use can use the UI, or use the following command in the package manager console:
```
Install-Package NumberRanges
```

## Contributing
If you want to contribute, please create a pull request. I will review it as soon as possible.
Use visual studio 2022 version 17.8 or later to build this library. The main library targets NETStandard 2.0, but the tests use .NET 8.0.

## Author
This library was created by Jan Geert Hek, a software developer from the Netherlands. You can find more information about me on my [LinkedIn](https://www.linkedin.com/in/jghek/) page.

## License
This library is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

# The manual

## What is a NumberRange?
A NumberRange is a range of integers. It uses the notation you may know from specifying pages when printing a document. 
It can be a single number, a range of numbers, or a combination of both. The range is defined by a string, like: `2-10,12,15-`. This means any number between 2 and 10, 12, and any number that is 15 or higher.

This library can help you to check if a number is in a range, and to create a range from a string and optimizing it.

## How to use NumberRanges
Using NumberRanges is easy. First, add the using statement to your code:
```csharp
using NumberRanges;
```

Then, create a new instance of the NumberRange class.
Here is a simple example.

```csharp
// Any int less than 3, or between 8 and 10, or 19 or more is in the range.
var range = new NumberRange("-2,4,6-7,9-");

// Check if a number is in the range
range.Contains(1); // returns true
range.Contains(2); // returns true
range.Contains(3); // returns false
range.Contains(4); // returns true
range.Contains(5); // returns false
range.Contains(6); // returns true
range.Contains(7); // returns true
range.Contains(8); // returns false
range.Contains(9); // returns true
```

Here is another example, that shows creating a new instance using a fluent api to create a range:

```csharp
var range = NumberRange.Empty
				.AddLowerThanOrEqual(6)
				.AddRange(8, 10)
				.Add(15)
				.Add("19-23")
				.AddGreaterThanOrEqual(25);

range.ToString(); // returns "-6,8-10,15,19-23,25-"
```

Please note that an empty constructor and `Empty` behave identical.
You can also provide an set of ranges to the constructor.

```csharp
var range = NumberRange("-6", "8-10", "15,19-23", "25-");
```

## Optimizing a range
The range `2,3,4,5,6-11,12,15-` can be optimized to `2-12,15-`. This is done by the `Optimize` method.

```csharp
var range = new NumberRange("2,3,4,5,6-11,12,15-");

range.ToString(); // returns "2,3,4,5,6-11,12,15-"

range.Optimize();

range.ToString(); // returns "2-12,15-"
```

## Credits

The icon used has been designed by Flaticon.com