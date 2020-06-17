using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Utility
{
    public static class Extensions
    {
        /// <summary>
        /// EntityToJson
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T t)
        {
            return JsonConvert.SerializeObject(t);
        }
        /// <summary>
        /// JsonToEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }
    }
}
