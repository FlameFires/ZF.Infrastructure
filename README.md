# ZF.Infrastructure
It is a infrastructure library of csharp.



## Installtation
`nuget install ZF.Infrastructure`



## Usage

### Mapper
```csharp
// The source text.
string html = @"<!DOCTYPE html>
<html>
<body>
	<h1 class='h1 24' data-test='123'>This is <b>bold</b> heading</h1>
	<p>This is <u>underlined</u> paragraph</p>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";

// Map the source text to the model.
var testModel = html.Mapper<TestModel>();
Assert.NotNull(testModel);

testOutputHelper.WriteLine("The underlined result is \"{0}\"", testModel.underlined);
Assert.Equal("<u>underlined</u>", testModel.underlined);
// Output:
//         The underlined result is "&lt;u&gt;underlined&lt;/u&gt;"

testOutputHelper.WriteLine("The h2 result is \"{0}\"", testModel.h2);
Assert.Equal("This is <i>italic</i> heading", testModel.h2);
// Output:
//         The h2 result is "This is <i>italic</i> heading"

testOutputHelper.WriteLine("The h1 result is \"{0}\"", testModel.h1);
Assert.Equal("-", testModel.h1);
// Output:
//         The h1 result is "-"


public class TestModel
{
    [ReQuery("data-test")]
    [ReSubstring("data", "test")]
    public string h1 { get; set; }

    [ReQuery("<u>(.*?)</u>")]
    public string underlined { get; set; }

    [ReSubstring("h2>", "</h2")]
    public string h2 { get; set; }
}
```

### Regex Extension
```csharp
/// <summary>
/// Query the string according to the pattern
/// </summary>
/// <param name="source"></param>
/// <param name="pattern"></param>
/// <returns></returns>
public static string QuerySingle(this string source, string pattern) 

/// <summary>
/// Query the string according to the pattern
/// </summary>
/// <param name="source"></param>
/// <param name="pattern"></param>
/// <returns></returns>
public static List<string> QueryMultiple(this string source, string pattern) 

/// <summary>
/// Substring the string between the start and end strings
/// </summary>
/// <param name="source"></param>
/// <param name="startStr"></param>
/// <param name="endStr"></param>
/// <returns></returns>
public static string SubstringSingle(this string source, string startStr, string endStr)

/// <summary>
/// Substring the string between the start and end strings
/// </summary>
/// <param name="source"></param>
/// <param name="startStr"></param>
/// <param name="endStr"></param>
/// <returns></returns>
public static List<string>? SubstringMultiple(this string source, string startStr, string endStr)
```