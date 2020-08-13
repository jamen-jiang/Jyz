﻿using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class ModuleService : BaseService, IModuleService
    {
        private readonly IMapper _mapper;
        public ModuleService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 根据privilegeIds获取模块列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        public List<Module> GetListByPrivilegeIds(List<Guid> privilegeIds)
        {
            using (var db = NewDB())
            {
                var moduleIds = db.Privilege.Where(x => privilegeIds.Contains(x.Id) && x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                List<Module> modules = db.Module.WhereByModuleIds(moduleIds).ToList();
                return modules;
            }
        }
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ModuleResponse>> Query(ModuleRequest info)
        {
            using (var db = NewDB())
            {
                var query =  db.Module.AsNoTracking();
                if (!info.Name.IsNullOrEmpty())
                    query = query.Where(x => x.Name.Contains(info.Name));
                List<Module> modules = await query.ToListAsync();
                var dtos = _mapper.Map<List<ModuleResponse>>(modules);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var list = new List<ModuleResponse>();
                foreach (ModuleResponse p in pDtos)
                {
                    list.Add(p);
                    CreateModuleTree(p, dtos);
                }
                return list;
            }
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModuleResponse> Detail(Guid id)
        {
            using (var db = NewDB())
            {
                var module = await db.Module.FindByIdAsync(id);
                return _mapper.Map<ModuleResponse>(module);
            }
        }
        /// <summary>
        /// 获取模块目录列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComboBoxTreeResponse>> GetModuleCatalogs()
        {
            using (var db = NewDB())
            {
               var modules = await db.Module.AsNoTracking().Where(x=>x.Type == (int)ModuleTypeEnum.Catalog).ToListAsync();
                var dtos = _mapper.Map<List<ComboBoxTreeResponse>>(modules);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var list = new List<ComboBoxTreeResponse>();
                foreach (var p in pDtos)
                {
                    list.Add(p);
                    CreateTree(p, dtos);
                }
                return list;
            }
        }
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComboBoxTreeResponse>> GetModules()
        {
            using (var db = NewDB())
            {
                var modules = await db.Module.AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<ComboBoxTreeResponse>>(modules);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var list = new List<ComboBoxTreeResponse>();
                foreach (var p in pDtos)
                {
                    list.Add(p);
                    CreateTree(p, dtos);
                }
                return list;
            }
        }
        private void CreateModuleTree(ModuleResponse node, List<ModuleResponse> dtos)
        {
            var childs = dtos.Where(x => x.PId == node.Id).ToList();
            foreach (var c in childs)
            {
                node.Children.Add(c);
                CreateModuleTree(c, dtos);
            }
        }
        private void CreateTree(ComboBoxTreeResponse node, List<ComboBoxTreeResponse> dtos)
        {
            var childs = dtos.Where(x => x.PId.ToGuid() == node.Id.ToGuid()).ToList();
            foreach (var c in childs)
            {
                node.Children.Add(c);
                CreateTree(c, dtos);
            }
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        public async Task Add(ModuleAddRequest info)
        {
            if (info.PId == null)
            {
                if (info.Type == (int)ModuleTypeEnum.Menu)
                {
                    throw new ApiException("顶级目录类型不能为菜单!");
                }
            }
            using (var db = NewDB())
            {
                Module model = _mapper.Map<Module>(info);
                BeforeAddOrModify(model);
                await db.Module.AddAsync(model);
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Modify(ModuleModifyRequest info)
        {
            if (info.PId == null)
            {
                if (info.Type == (int)ModuleTypeEnum.Menu)
                {
                    throw new ApiException("顶级目录类型不能为菜单!");
                }
            }
            using (var db = NewDB())
            {
                var model = await db.Module.FindByIdAsync(info.Id);
                _mapper.Map(info, model);
                BeforeAddOrModify(model);
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 获取当前模块及下面所有模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetCurrentAndChildrenIdList(Guid id)
        {
            using (var db = NewDB())
            {
                var modules = await db.Module.AsNoTracking().ToListAsync();
                List<Guid> idList = new List<Guid>();
                idList.Add(id);
                GetChildrenDepartmentIdList(modules, idList, id);
                return idList;
            }
        }
        /// <summary>
        /// 获取当前模块及下面所有模块
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="idList"></param>
        /// <param name="id"></param>
        private void GetChildrenDepartmentIdList(List<Module> modules, List<Guid> idList, Guid pId)
        {
            var childrens = modules.Where(x => x.PId == pId).Select(s => s.Id).ToList();
            if (childrens.Count > 0)
            {
                idList.AddRange(childrens);
                foreach (Guid id in childrens)
                {
                    GetChildrenDepartmentIdList(modules, idList, id);
                }
            }
        }
    }
}
