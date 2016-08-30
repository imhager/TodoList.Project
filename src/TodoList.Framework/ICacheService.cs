using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Framework
{
    public interface ICacheService
    {
        void Store(string key, object content);

        void Store(string key, object content, int duration);

        T Get<T>(string key) where T : class;
    }
}
