using System.Reflection;

namespace ZF.Infrastructure;

public class Mapper
{
    public T Map<T>(string content) where T : class, new()
    {
        var obj = Activator.CreateInstance<T>();
        return Map<T>(content, obj);
    }
    
    public T Map<T>(string content, T source) where T : class, new()
    {
        var obj = source;
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
        foreach (var property in properties)
        {
            // Judge whether the property is an enumerable type
            var isEnumerable = property.PropertyType.IsGenericType && property.PropertyType.IsAssignableTo(typeof(IEnumerable<string>));
            
            // Get all attributes of the property
            var propertyAttribute = property.GetCustomAttributes().ToArray();

            if (propertyAttribute.Length == 0)
                continue;

            // The result of the property
            object? result = null;
            foreach (var attribute in propertyAttribute)
            {
                // Judge whether the attribute is ReQueryAttribute
                if (attribute is ReQueryAttribute reQueryAttribute)
                {
                    var pattern = reQueryAttribute.Pattern;
                    var defaultValue = reQueryAttribute.DefaultValue;

                    if (isEnumerable)
                    {
                        // TODO: Implement the logic for ReQueryAttribute with multiple results
                    }
                    else
                    {
                        var regexStr = RegexUtil.QuerySingle(content, pattern);

                        if (string.IsNullOrEmpty(regexStr) && !string.IsNullOrEmpty(reQueryAttribute.DefaultValue))
                        {
                            regexStr = reQueryAttribute.DefaultValue;
                        }


                        if (!string.IsNullOrEmpty(regexStr))
                        {
                            switch (reQueryAttribute.Trim)
                            {
                                case TrimType.Start:
                                    regexStr = regexStr.TrimStart();
                                    break;
                                case TrimType.End:
                                    regexStr = regexStr.TrimEnd();
                                    break;
                                case TrimType.Both:
                                    regexStr = regexStr.Trim();
                                    break;
                            }
                        }

                        result = regexStr;
                    }
                }

                // Judge whether the attribute is ReSubstringAttribute
                if (attribute is ReSubstringAttribute reSubstringAttribute)
                {
                    var startStr = reSubstringAttribute.StartStr;
                    var endStr = reSubstringAttribute.EndStr;
                    var defaultValue = reSubstringAttribute.DefaultValue;

                    if (isEnumerable)
                    {
                        IEnumerable<string>? regexList = RegexUtil.SubstringMultiple(content, startStr, endStr);

                        if (regexList != null && reSubstringAttribute.DefaultValue != null && !regexList.Any() && reSubstringAttribute.DefaultValue.GetType().IsAssignableTo(property.PropertyType))
                        {
                            regexList = reSubstringAttribute.DefaultValue as IEnumerable<string>;
                        }

                        var regexArr = regexList?.ToArray();
                        if (regexArr != null && regexArr.Any())
                        {
                            switch (reSubstringAttribute.Trim)
                            {
                                case TrimType.Start:
                                    regexList = regexArr.Select(x => x.TrimStart());
                                    break;
                                case TrimType.End:
                                    regexList = regexArr.Select(x => x.TrimEnd());
                                    break;
                                case TrimType.Both:
                                    regexList = regexArr.Select(x => x.Trim());
                                    break;
                            }
                        }

                        result = regexList;
                    }
                    else
                    {
                        var regexStr = RegexUtil.SubstringSingle(content, startStr, endStr);

                        if (string.IsNullOrEmpty(regexStr) && !string.IsNullOrEmpty(reSubstringAttribute.DefaultValue?.ToString()))
                        {
                            regexStr = reSubstringAttribute.DefaultValue.ToString();
                        }

                        if (!string.IsNullOrEmpty(regexStr))
                        {
                            switch (reSubstringAttribute.Trim)
                            {
                                case TrimType.Start:
                                    regexStr = regexStr.TrimStart();
                                    break;
                                case TrimType.End:
                                    regexStr = regexStr.TrimEnd();
                                    break;
                                case TrimType.Both:
                                    regexStr = regexStr.Trim();
                                    break;
                            }
                        }

                        result = regexStr;
                    }
                }
            }


            if (result != null)
            {
                // Set the value of the property
                property.SetValue(obj, result);
            }
        }

        return obj;
    }
}