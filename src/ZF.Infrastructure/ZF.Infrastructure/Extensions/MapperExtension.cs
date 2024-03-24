namespace ZF.Infrastructure;

public static class MapperExtension
{
    public static T Mapper<T>(this string html) where T : class, new()
    {
        var mapper = new Mapper();
        return mapper.Map<T>(html);
    }
}