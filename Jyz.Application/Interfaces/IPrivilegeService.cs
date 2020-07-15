using Jyz.Application.Dtos;
using Jyz.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Interfaces
{
    public interface IPrivilegeService
    {
        List<PrivilegeDto> GetPrivilegeByUserId(Guid userId);
        /// <summary>
        /// 根据用户Id获取授权的菜单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<AuthorizeModuleDto> GetAuthorizeModules(Guid userId);
    }
}
