using Xunit.Abstractions;

namespace ZF.Infrastructure.Test;

public class RegexExtensionTest(ITestOutputHelper testOutputHelper)
{
    string html = @"<!DOCTYPE html>
                    <html>
                    <body>
	                    <h1 class='h1 24' data-test='123'>This is <b>bold</b> heading</h1>
	                    <p>This is <u>underlined</u> paragraph</p>
	                    <h2>This is <i>italic</i> heading</h2>
                    </body>
                    </html> ";
    
    [Fact]
    public void TestReQuery()
    {
        var substringSingle = html.SubstringSingle("<p>", "</p>");
        Assert.NotEmpty(substringSingle);

        testOutputHelper.WriteLine("The substringSingle result is \"{0}\"", substringSingle);
        Assert.Equal("This is <u>underlined</u> paragraph", substringSingle);
    }
}