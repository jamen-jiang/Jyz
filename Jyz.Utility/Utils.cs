using System;

namespace Jyz.Utility
{
    public static class Utils
    {
        /// <summary>
        /// 获取枚举的名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static string GetEnumName<T>(string value, bool ignoreCase = true)
        {
            var t = (T)Enum.Parse(typeof(T), value, ignoreCase);
            System.Reflection.FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return t.ToString();
            else
                return (attribArray[0] as System.ComponentModel.DescriptionAttribute).Description;
        }
        #region 时间戳操作
        /// <summary>
        /// 时间戳转成时间类型
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        //public static DateTime TimeStamp2DateTime(string timeStamp)
        //{
        //    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        //    long lTime = long.Parse(timeStamp + "0000000");
        //    TimeSpan toNow = new TimeSpan(lTime);
        //    return dtStart.Add(toNow);
        //}

        /// <summary>
        /// 时间类型转成时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        //public static string DateTime2TimeStamp(System.DateTime time)
        //{
        //    long timeStamp = 0;
        //    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        //    timeStamp = (long)(time - startTime).TotalSeconds;
        //    return timeStamp.ToString();
        //}
        #endregion
    }
}
