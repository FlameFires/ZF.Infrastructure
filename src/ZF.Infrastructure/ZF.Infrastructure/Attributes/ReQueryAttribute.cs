namespace ZF.Infrastructure;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ReQueryAttribute : Attribute
{
    public ReQueryAttribute(string pattern, string? defaultValue = null, TrimType trim = TrimType.None)
    {
        Pattern = pattern;
        DefaultValue = defaultValue;
        Trim = trim;
    }

    public string Pattern { get; set; }

    public string? DefaultValue { get; set; }

    public TrimType Trim { get; set; }
}