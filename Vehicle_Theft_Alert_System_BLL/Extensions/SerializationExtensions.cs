using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Extensions
{
    public static class SerializationExtensions
    {
        public static string SerializeWithoutNullData<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, 
                Formatting.Indented,
                new JsonSerializerSettings 
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}
