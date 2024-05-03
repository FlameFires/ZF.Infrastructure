using Xunit.Abstractions;

namespace ZF.Infrastructure.Test;

public class RegexMapperTest(ITestOutputHelper testOutputHelper)
{
    string html = @"<!DOCTYPE html>
                    <html>
                    <body>
	                    <h1 class='h1 24' data-test='123'>This is <b>bold</b> heading</h1>
	                    <p>This is <u>underlined</u> paragraph</p>
	                    <h2>This is <i>italic</i> heading</h2>
                    </body>
                    </html> ";

    private class TestModel
    {
        [ReQuery("data-test")]
        [ReSubstring("data", "test")]
        public string h1 { get; set; }

        [ReQuery("<u>(.*?)</u>")]
        public string underlined { get; set; }

        [ReSubstring("h2>", "</h2")]
        public string h2 { get; set; }
    }

    [Fact]
    public void TestReQuery()
    {
        var testModel = html.Mapper<TestModel>();
        Assert.NotNull(testModel);

        testOutputHelper.WriteLine("The underlined result is \"{0}\"", testModel.underlined);
        Assert.Equal("<u>underlined</u>", testModel.underlined);
    }


    [Fact]
    public void TestReSubstring()
    {
        var testModel = html.Mapper<TestModel>();
        Assert.NotNull(testModel);

        testOutputHelper.WriteLine("The h2 result is \"{0}\"", testModel.h2);
        Assert.Equal("This is <i>italic</i> heading", testModel.h2);
    }


    [Fact]
    public void TestMultiReAttributes()
    {
        var testModel = html.Mapper<TestModel>();
        Assert.NotNull(testModel);

        testOutputHelper.WriteLine("The h1 result is \"{0}\"", testModel.h1);
        Assert.Equal("-", testModel.h1);
    }
}