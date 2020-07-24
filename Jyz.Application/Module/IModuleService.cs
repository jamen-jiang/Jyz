using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public interface IModuleService
    {
        /// <summary>
        /// 根据privilegeIds获取模块列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        List<Module> GetListByPrivilegeIds(List<Guid> privilegeIds);
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="isEnable">是否包含软删除(默认不包含)</param>
        /// <returns></returns>
        Task<List<ModuleResponse>> Get(bool isEnable = false);
    }
}
