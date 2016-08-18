using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Framework
{
    public interface IJsonSerializable
    {
        string ToJson(object value);
        T ToObject<T>(string value) where T : class, new();
    }
}
