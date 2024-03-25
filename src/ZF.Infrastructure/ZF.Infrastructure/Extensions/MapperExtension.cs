namespace ZF.Infrastructure;

public static class MapperExtension
{
    public static T Mapper<T>(this string content) where T : class, new()
    {
        var mapper = new Mapper();
        return mapper.Map<T>(content);
    }
    
    public static T Mapper<T>(this string content, T source) where T : class, new()
    {
        var mapper = new Mapper();
        return mapper.Map<T>(content, source);
    }
}