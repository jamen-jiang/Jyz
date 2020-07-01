using System.ComponentModel;

namespace Jyz.Domain.Enums
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
}
