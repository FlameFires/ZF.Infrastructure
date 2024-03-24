using System.Text.RegularExpressions;

namespace ZF.Infrastructure;

internal class RegexUtil
{
    /// <summary>
    /// Query the string according to the pattern
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static string QuerySingle(string source, string pattern)
    {
        Regex rg = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);
        return rg.Match(source).Value;
    }

    /// <summary>
    /// Query the string according to the pattern
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static List<string> QueryMultiple(string source, string pattern)
    {
        Regex rg = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);

        MatchCollection matches = rg.Matches(source);

        List<string> resList = new List<string>();

        foreach (Match item in matches)
            resList.Add(item.Value);

        return resList;
    }

    /// <summary>
    /// Substring the string between the start and end strings
    /// </summary>
    /// <param name="source"></param>
    /// <param name="startStr"></param>
    /// <param name="endStr"></param>
    /// <returns></returns>
    public static string SubstringSingle(string source, string startStr, string endStr)
    {
        var regexStr = $"(?<=({startStr}))[.\\s\\S]*?(?=({endStr}))";
        Regex rg = new Regex(regexStr, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);
        return rg.Match(source).Value;
    }

    /// <summary>
    /// Substring the string between the start and end strings
    /// </summary>
    /// <param name="source"></param>
    /// <param name="startStr"></param>
    /// <param name="endStr"></param>
    /// <returns></returns>
    public static List<string>? SubstringMultiple(string source, string startStr, string endStr)
    {
        var regexStr = $"(?<=({startStr}))[.\\s\\S]*?(?=({endStr}))";
        Regex rg = new Regex(regexStr, RegexOptions.Singleline | RegexOptions.Compiled);

        MatchCollection matches = rg.Matches(source);

        List<string>? resList = new List<string>();

        foreach (Match item in matches)
            resList.Add(item.Value);

        return resList;
    }
}