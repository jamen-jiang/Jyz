using System.ComponentModel;

namespace Jyz.Domain.Enum
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperateTypeEnum
    {
        [Description("操作")]
        Operate = 0,
        [Description("请求")]
        Request = 1
    }
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuTypeEnum
    {
        [Description("目录")]
        Catalog = 0,
        [Description("菜单")]
        Menu = 1,
    }
    /// <summary>
    /// 权限对象
    /// </summary>
    public enum MasterEnum
    {
        [Description("角色")]
        Role = 0,
        [Description("用户")]
        User = 1
    }
    /// <summary>
    /// 权限通道
    /// </summary>
    public enum AccessEnum
    {
        [Description("菜单")]
        Menu,
        [Description("模块")]
        Module,
        [Description("操作")]
        Operate,
    }
    /// <summary>
    /// Api状态
    /// </summary>
    public enum ApiStatusEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 200,
        /// <summary>
        /// 令牌无效
        /// </summary>
        [Description("令牌无效")]
        FAIL_TOKEN_UNVALID = 1,
        /// <summary>
        /// 令牌过期
        /// </summary>
        [Description("令牌过期")]
        EXPIRED_TOKEN_UNVALID = 2,
        /// <summary>
        /// 没访问权限
        /// </summary>
        [Description("没访问权限")]
        FAIL_PERMISSION = 3,
        /// <summary>
        /// 应用程序错误
        /// </summary>
        [Description("应用程序错误")]
        FAIL_APP = 98,
        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        FAIL_EXCEPTION = 99,
        /// <summary>
        /// 403
        /// </summary>
        [Description("403")]
        FAIL_CODE = 403
    }
}
