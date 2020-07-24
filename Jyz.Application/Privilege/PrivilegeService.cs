using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class PrivilegeService : BaseService, IPrivilegeService
    {
        private readonly IMapper _mapper;
        public PrivilegeService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<PrivilegeResponse> GetPrivilegeByUserId(Guid userId)
        {
            using (var db = NewDB())
            {
                Guid[] roleIdList = db.Role.WhereByUserId(userId).Select(s => s.Id).ToArray();
                List<Privilege> privilegeList = db.Privilege.Get(MasterEnum.Role, roleIdList).ToList();
                Guid[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                List<Module> moduleList = db.Module.Where(x => moduleIds.Contains(x.Id)).ToList();
                List<Operate> operateList = db.Operate.Where(x => operateIds.Contains(x.Id)).ToList();
                List<PrivilegeResponse> list = new List<PrivilegeResponse>();
                foreach (var m in moduleList)
                {
                    var tempOperateList = operateList.Where(x => x.ModuleId == m.Id).ToList();
                    foreach (var o in tempOperateList)
                    {
                        PrivilegeResponse model = new PrivilegeResponse();
                        model.ModuleId = m.Id;
                        model.Controller = m.Controller;
                        model.OperateId = o.Id;
                        model.Action = o.Action;
                        list.Add(model);
                    }
                }
                return list;
            }
        }
        /// <summary>
        /// 根据用户Id获取授权的菜单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ModuleResponse> GetAuthorizeModules(Guid userId)
        {
            using (var db = base.NewDB())
            {
                List<Module> modules = null;
                List<Operate> operates = null;
                //如果是管理员
                if (userId == AppSetting.Project.Admin.ToGuid())
                {
                    //取出所有模块所有操作
                    modules = db.Module.AsNoTracking().ToList();
                    operates = db.Operate.AsNoTracking().ToList();
                }
                else
                {
                    Guid[] roleIdList = db.Role.WhereByUserId(userId).Select(s => s.Id).ToArray();
                    List<Privilege> privilegeList = db.Privilege.Get(MasterEnum.Role, roleIdList).ToList();
                    Guid[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                    Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                    modules = db.Module.Where(x => moduleIds.Contains(x.Id)).ToList();
                    operates = db.Operate.Where(x => operateIds.Contains(x.Id)).ToList();
                }
                var operateDtos = _mapper.Map<List<OperateResponse>>(operates);
                var moduleDtos = _mapper.Map<List<ModuleResponse>>(modules);
                List<ModuleResponse> list = new List<ModuleResponse>();
                List<ModuleResponse> pModules = moduleDtos.Where(x => x.PId == null).ToList();
                foreach (var p in pModules)
                {
                    CreateModuleTree(p, moduleDtos, operateDtos);
                    list.Add(p);
                }
                return list;
            }
        }
        /// <summary>
        /// 获取模块树及权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<ModuleAndPrivilegeResponse> GetModuleAndPrivilege(Guid roleId)
        {
            using (var db = NewDB())
            {
                ModuleAndPrivilegeResponse model = new ModuleAndPrivilegeResponse();
                List<Module> modules = await db.Module.AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<ModuleResponse>>(modules);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var operates = db.Operate.AsNoTracking().ToList();
                var operateDto = _mapper.Map<List<OperateResponse>>(operates);
                foreach (ModuleResponse p in pDtos)
                {
                    model.Modules.Add(p);
                    CreateModuleTree(p, dtos, operateDto);
                }
                model.SelectedModules = await db.Privilege.Get(MasterEnum.Role, AccessEnum.Module, roleId).Select(s => s.AccessValue).ToListAsync();
                model.SelectedOperates = await db.Privilege.Get(MasterEnum.Role, AccessEnum.Operate, roleId).Select(s => s.AccessValue).ToListAsync();
                return model;
            }
        }
        private void CreateModuleTree(ModuleResponse node, List<ModuleResponse> list, List<OperateResponse> operates)
        {
            var childList = list.Where(x => x.PId == node.Id).ToList();
            foreach (var c in childList)
            {
                c.Operates = operates.Where(x => x.ModuleId == c.Id).ToList();
                node.Children.Add(c);
                CreateModuleTree(c, list, operates);
            }
        }
    }
}
