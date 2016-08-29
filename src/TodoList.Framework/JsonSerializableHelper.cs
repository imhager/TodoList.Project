using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TodoList.Framework
{
    public class JsonSerializableHelper : IJsonSerializable
    {
        public string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T ToObject<T>(string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(value);
        }


        public JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings()
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public class LowercaseContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}
