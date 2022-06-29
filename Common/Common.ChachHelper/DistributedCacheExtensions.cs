using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Common.ChachHelper;


public static class DistributedCacheExtensions
{
    public static async Task<T?> GetOrSet<T>(this IDistributedCache cache, string key, Func<Task<T>> func, CacheOptions options)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
        {
            var res = await func();
            if (res == null)
                return default;

            await SetCache(cache, key, res, options);
            return res;
        }
        var data = JsonSerializer.Deserialize<T>(val);
        return data;
    }

    public static async Task<T?> GetOrSet<T>(this IDistributedCache cache, string key, Func<Task<T>> func)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
        {
            var res = await func();
            if (res == null)
                return default;

            await SetCache(cache, key, res);
            return res;
        }
        var data = JsonSerializer.Deserialize<T>(val);
        return data;
    }

    public static Task SetCache<T>(this IDistributedCache cache, string key, T value)
    {
        return SetCache(cache, key, value, new CacheOptions());
    }

    private static async Task SetCache<T>(this IDistributedCache cache, string key, T value, CacheOptions options)
    {
        var json = JsonSerializer.Serialize(value);
        var bytes = Encoding.UTF8.GetBytes(json);

        await cache.SetAsync(key, bytes, new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(options.AbsoluteExpirationCacheFromMinutes),
            SlidingExpiration = TimeSpan.FromMinutes(options.ExpireSlidingCacheFromMinutes),
        });
    }

    public static async Task<T?> GetAsync<T>(this IDistributedCache cache, string key)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
            return default;

        var value = JsonSerializer.Deserialize<T>(val);
        return value;
    }
}

public class CacheOptions
{
    public int ExpireSlidingCacheFromMinutes { get; set; } = 5;
    public int AbsoluteExpirationCacheFromMinutes { get; set; } = 10;
}