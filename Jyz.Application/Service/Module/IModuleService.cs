﻿using Jyz.Domain;
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
        /// <param name="info"></param>
        /// <returns></returns>
        Task<List<ModuleResponse>> Query(ModuleRequest info);
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
        Task<List<ComboBoxTreeResponse>> GetModuleCatalogs();
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <returns></returns>
        Task<List<ComboBoxTreeResponse>> GetModules();
        /// <summary>
        /// 添加模块
        /// <param name="info"></param>
        /// </summary>
        Task Add(ModuleAddRequest info);
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task Modify(ModuleModifyRequest info);
        /// <summary>
        /// 获取当前模块及下面所有模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Guid>> GetCurrentAndChildrenIdList(Guid id);
    }
}
