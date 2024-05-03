namespace ZF.Infrastructure;

public static class RegexExtension
{
    /// <summary>
    /// Query the string according to the pattern
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static string QuerySingle(this string source, string pattern) => RegexUtil.QuerySingle(source, pattern);

    /// <summary>
    /// Query the string according to the pattern
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static List<string> QueryMultiple(this string source, string pattern) => RegexUtil.QueryMultiple(source, pattern);
    
    /// <summary>
    /// Substring the string between the start and end strings
    /// </summary>
    /// <param name="source"></param>
    /// <param name="startStr"></param>
    /// <param name="endStr"></param>
    /// <returns></returns>
    public static string SubstringSingle(this string source, string startStr, string endStr)=> RegexUtil.SubstringSingle(source, startStr, endStr);
    
    /// <summary>
    /// Substring the string between the start and end strings
    /// </summary>
    /// <param name="source"></param>
    /// <param name="startStr"></param>
    /// <param name="endStr"></param>
    /// <returns></returns>
    public static List<string>? SubstringMultiple(this string source, string startStr, string endStr)=> RegexUtil.SubstringMultiple(source,  startStr, endStr);
}