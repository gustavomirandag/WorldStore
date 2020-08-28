using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Interfaces.Services;

namespace WorldStore.Common.Infra.Helper.Serializer
{
    public class SerializerService : ISerializerService
    {
        public T Deserialize<T>(string serializedObj)
        {
            //FLURL alternativa ao Newtonsoft
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
