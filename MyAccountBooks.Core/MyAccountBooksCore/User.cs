using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAccountBooks.Core.MyAccountBooksCore
{
    /// <summary>
    /// 登录账户表
    /// </summary>
   public  class User: CommonEntity<int>
    {     

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [DefaultValue("")]
        [StringLength(50)]
        public string  Mobile { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        [DefaultValue("")]
        [StringLength(20)]
        public int UserName { get; set; }

        /// <summary>
        /// 密码(才用MD5加密)
        /// </summary>
        [Required]
        [DefaultValue("")]
        [StringLength(64)]
        public string  PassWork { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [DefaultValue("")]
        [StringLength(200)]
        public string  Remark { get; set; }

    }
}
