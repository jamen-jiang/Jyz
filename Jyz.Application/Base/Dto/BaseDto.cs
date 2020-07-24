using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class BaseDto
    {
        public bool IsEnable { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid CreatedBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public virtual string CreatedByName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新人Id
        /// </summary>
        public virtual Guid? UpdatedBy { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        public virtual string UpdatedByName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdatedOn { get; set; }
    }
}
