using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Domain
{
    public class File : FullEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 后缀
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public long? Size { get; set; }
        /// <summary>
        /// 文件md5值，防止上传重复文件
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
