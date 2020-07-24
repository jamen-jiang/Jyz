using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class PageReqDto
    {
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
    }
}
