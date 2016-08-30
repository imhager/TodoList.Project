using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace TodoList.Framework
{
    public class MemoryCacheService : ICacheService
    {
        protected IMemoryCache Cache;
        private readonly IJsonSerializable _jsonSerializable;
        private static int DefaultCacheDuration => 60;

        public MemoryCacheService(IMemoryCache cache, IJsonSerializable jsonSerializable)
        {
            Cache = cache;
            _jsonSerializable = jsonSerializable;
        }

        public void Store(string key, object content)
        {
            Store(key, content, DefaultCacheDuration);
        }

        public void Store(string key, object content, int duration)
        {
            object cached;
            if (Cache.TryGetValue(key, out cached))
            {
                Cache.Remove(key);
            }

            Cache.Set(key, content, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(duration),
                Priority = CacheItemPriority.Low
            });

        }

        public T Get<T>(string key) where T : class
        {
            object result;
            if (Cache.TryGetValue(key, out result))
            {
                return result as T;
            }

            return null;
        }
    }
}
