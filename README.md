# ZF.Infrastructure
It is a infrastructure library of csharp.

## Installtation
`nuget install ZF.Infrastructure`

## Usage
```csharp
string html = @"<!DOCTYPE html>
<html>
<body>
	<h1 class='h1 24' data-test='123'>This is <b>bold</b> heading</h1>
	<p>This is <u>underlined</u> paragraph</p>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";

var testModel = html.Mapper<TestModel>();
Assert.NotNull(testModel);
_testOutputHelper.WriteLine(testModel.h1);
// Output: -

public class TestModel
{
    [ReQuery("data-test")]
    [ReSubstring("data", "test")]
    public string h1 { get; set; }
}
```


