using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain.Core
{
    [Serializable]
    public abstract class Entity : Entity<int>
    {

    }
    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        #region 公共属性
        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public virtual bool IsEnable { get; set; } = true;
        /// <summary>
        /// 创建人Id
        /// </summary>
        [Required]
        public TPrimaryKey CreatedBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public virtual string CreatedByName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新人Id
        /// </summary>
        public virtual TPrimaryKey? UpdatedBy { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public virtual string UpdatedByName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(TypeName = "datetime")]
        public virtual DateTime? UpdatedOn { get; set; }
        #endregion
    }
}