using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyz.Domain.Request
{
    public class ApiRequest
    {
        public string Code { get; set; }
        public string Token { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        public dynamic Params { get; set; }
        public ApiWorkContext ApiWorkContext { get; set; }
    }
    /// <summary>
    /// API上下文信息
    /// </summary>
    public class ApiWorkContext
    {
        public int UserId { get; set; }
    }
}
