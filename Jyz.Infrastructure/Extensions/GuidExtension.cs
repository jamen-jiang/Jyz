using System;

namespace Jyz.Infrastructure
{
    public static class GuidExtension
    {
        /// <summary>
        /// 字符串转Guid
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string str)
        {
            Guid guid;
            if (Guid.TryParse(str, out guid))
                return guid;
            return Guid.Empty;
        }
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty ? true : false;
        }
    }
}
