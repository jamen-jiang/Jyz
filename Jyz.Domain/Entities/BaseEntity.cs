using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool IsEnable { get; set; } = true;
        /// <summary>
        /// 创建人Id
        /// </summary>
        [Required]
        public Guid CreatedBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedByName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新人Id
        /// </summary>
        public Guid? UpdatedBy { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string UpdatedByName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}