using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.ViewModels
{
    /// <summary>
    /// 授权菜单
    /// </summary>
    public class AuthorizeModuleDto
    {
        public Guid Id { get; set; }
        public Guid? PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
        public List<AuthorizeOperateDto> OperateList { get; set; } = new List<AuthorizeOperateDto>();
        public List<AuthorizeModuleDto> Children { get; set; } = new List<AuthorizeModuleDto>();
    }
    /// <summary>
    /// 授权操作
    /// </summary>
    public class AuthorizeOperateDto
    {
        public Guid ModuleId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
