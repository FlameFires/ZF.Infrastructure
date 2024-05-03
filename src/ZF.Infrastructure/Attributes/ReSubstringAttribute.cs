namespace ZF.Infrastructure;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ReSubstringAttribute : Attribute
{
    public ReSubstringAttribute(string startStr, string endStr, object? defaultValue = null, TrimType trim = TrimType.None)
    {
        StartStr = startStr;
        EndStr = endStr;
        DefaultValue = defaultValue;
        Trim = trim;
    }

    public string StartStr { get; set; }

    public string EndStr { get; set; }

    public object? DefaultValue { get; set; }

    public TrimType Trim { get; set; }
}