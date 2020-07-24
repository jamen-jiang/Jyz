using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Jyz.Infrastructure
{
    public class Utils
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="isAddEmpty"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetEnumDict(Type enumType, bool isAddEmpty = false)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (isAddEmpty)
            {
                dict.Add("", "");
            }
            foreach (int i in Enum.GetValues(enumType))
            {
                string name = GetEnumName(enumType, i);
                dict.Add(i.ToString(), name);
            }
            return dict;
        }
        public static string GetEnumName(Type type, int value)
        {
            var t = Enum.Parse(type, Enum.GetName(type, value));
            MemberInfo[] memInfo = type.GetMember(t.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return t.ToString();//如果不存在描述，则返回枚举名称
        }
    }
}
