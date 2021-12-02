using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAccountBooks.Core.MyAccountBooksCore
{
    /// <summary>
    /// 公共的实体字段
    /// </summary>
  public   class CommonEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        [DefaultValue(0)]
        public bool  IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DefaultValue("3000-12-31 00:00:00")]
        public DateTime CreatedTime  { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Required]
        [DefaultValue("3000-12-31 00:00:00")]
        public DateTime DeletedTime  { get; set; }
    }
}
