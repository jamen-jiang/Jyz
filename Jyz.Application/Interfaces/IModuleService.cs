using Jyz.Application.ViewModels;
using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Interfaces
{
     public interface IModuleService
    {
        /// <summary>
        /// 根据privilegeIds获取模块列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        List<Module> GetListByPrivilegeIds(List<Guid> privilegeIds);
    }
}
