using Jyz.Application.Dtos;
using Jyz.Application.Interfaces;
using Jyz.Application.ViewModels;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Configuration;
using Jyz.Infrastructure.Data.Extensions;
using Jyz.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jyz.Application.Services
{
    public class PrivilegeService :BaseService, IPrivilegeService
    {
        public List<PrivilegeDto> GetPrivilegeByUserId(Guid userId)
        {
            using (var db = NewDB())
            {
                Guid[] roleIdList = db.Role.WhereByUserId(userId).Select(s => s.Id).ToArray();
                List<Privilege> privilegeList = db.Privilege.WhereByMaster(MasterEnum.Role, roleIdList).ToList();
                Guid[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                List<Module> moduleList = db.Module.Where(x => moduleIds.Contains(x.Id)).ToList();
                List<Operate> operateList = db.Operate.Where(x => operateIds.Contains(x.Id)).ToList();
                List<PrivilegeDto> list = new List<PrivilegeDto>();
                foreach (var m in moduleList)
                {
                    var tempOperateList = operateList.Where(x => x.ModuleId == m.Id).ToList();
                    foreach (var o in tempOperateList)
                    {
                        PrivilegeDto model = new PrivilegeDto();
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
        public List<AuthorizeModuleDto> GetAuthorizeModules(Guid userId)
        {
            using (var db = base.NewDB())
            {
                List<Module> modules = null;
                List<Operate> operates = null;
                //如果是管理员
                if (userId == AppSetting.Project.Admin.ToGuid())
                {
                    //取出所有模块所有操作
                    modules = db.Module.Query().ToList();
                    operates = db.Operate.Query().ToList();
                }
                else
                {
                    Guid[] roleIdList = db.Role.WhereByUserId(userId).Select(s => s.Id).ToArray();
                    List<Privilege> privilegeList = db.Privilege.WhereByMaster(MasterEnum.Role, roleIdList).ToList();
                    Guid[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                    Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                    modules = db.Module.Where(x => moduleIds.Contains(x.Id)).ToList();
                    operates = db.Operate.Where(x => operateIds.Contains(x.Id)).ToList();
                }
                //model.OperateList = operateList.Select(s => new OperateTree()
                //{
                //    MenuId = s.MenuId,
                //    Code = s.Code,
                //    Icon = s.Icon,
                //    Type = s.Type
                //}).ToList();
                List<AuthorizeModuleDto> list = new List<AuthorizeModuleDto>();
                List<Module> pModules = modules.Where(x => x.PId == null).ToList();
                foreach (var l in pModules)
                {
                    AuthorizeModuleDto node = new AuthorizeModuleDto
                    {
                        Id = l.Id,
                        PId = l.PId,
                        Type = l.Type,
                        Name = l.Name,
                        Controller = l.Controller,
                        Icon = l.Icon,
                        Sort = l.Sort,
                        VueUri = l.VueUri,
                        Remark = l.Remark,
                    };
                    CreateMenuTree(node, modules, operates);
                    list.Add(node);
                }
                return list;
            }
        }
        private void CreateMenuTree(AuthorizeModuleDto node, List<Module> list, List<Operate> oplist)
        {
            var childList = list.Where(x => x.PId == node.Id).ToList();
            foreach (var c in childList)
            {
                AuthorizeModuleDto n = new AuthorizeModuleDto
                {
                    Id = c.Id,
                    PId = c.PId,
                    Type = c.Type,
                    Name = c.Name,
                    Controller = c.Controller,
                    Icon = c.Icon,
                    Sort = c.Sort,
                    VueUri = c.VueUri,
                    Remark = c.Remark,
                    //OperateTreeList = oplist.Where(x => x.MenuId == c.Id).Select(s => new OperateTree()
                };
                node.Children.Add(n);
                CreateMenuTree(n, list, oplist);
            }
        }
    }
}
