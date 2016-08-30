using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace TodoList.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        private static int DefaultCacheDuration => 60;
        private readonly IJsonSerializable _jsonSerializable;

        public RedisCacheService(IDistributedCache cache, IJsonSerializable jsonSerializable)
        {
            _cache = cache;
            _jsonSerializable = jsonSerializable;
        }

        public void Store(string key, object content)
        {
            Store(key, content, DefaultCacheDuration);
        }

        public void Store(string key, object content, int duration)
        {
            string toStore;
            if (content is string)
            {
                toStore = (string)content;
            }
            else
            {
                toStore = _jsonSerializable.ToJson(content);
            }

            duration = duration <= 0 ? DefaultCacheDuration : duration;
            _cache.Set(key, Encoding.UTF8.GetBytes(toStore), new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(duration)
            });
        }

        public T Get<T>(string key) where T : class
        {
            var fromCache = _cache.Get(key);
            if (fromCache == null)
            {
                return null;
            }

            var str = Encoding.UTF8.GetString(fromCache);
            if (typeof(T) == typeof(string))
            {
                return str as T;
            }

            return _jsonSerializable.ToObject<T>(str);
        }
    }
}
