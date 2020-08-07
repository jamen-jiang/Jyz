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
        /// <returns></returns>
        Task<List<ModuleResponse>> Query();
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ModuleResponse> Detail(Guid id);
        /// <summary>
        /// 获取模块目录列表
        /// </summary>
        /// <returns></returns>
        Task<List<ComboBoxTreeResponse>> GetGetModuleCatalogs();
        /// <summary>
        /// 添加模块
        /// </summary>
        Task Add(ModuleRequest info);
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task Modify(ModuleRequest info);
    }
}
