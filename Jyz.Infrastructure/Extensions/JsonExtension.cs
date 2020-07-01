﻿using Newtonsoft.Json;

namespace Jyz.Infrastructure.Extensions
{
    public static class JsonExtension
    {
        /// <summary>
        /// ObjectToJson
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }
        /// <summary>
        /// JsonToEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return default;
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
