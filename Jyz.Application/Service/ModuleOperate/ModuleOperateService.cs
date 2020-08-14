using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class ModuleOperateService:BaseService,IModuleOperateService
    {
        private readonly IMapper _mapper;
        public ModuleOperateService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 获取模块操作树
        /// </summary>
        /// <returns></returns>
        public async Task<List<ModuleOperateResponse>> GetModuleOperates()
        {
            using (var db = NewDB())
            {
                List<Module> modules = await db.Module.AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<ModuleOperateResponse>>(modules);
                var operates = db.Operate.AsNoTracking().ToList();
                var operateDtos = _mapper.Map<List<OperateResponse>>(operates);
                foreach (var m in dtos)
                {
                    m.Operates = operateDtos.Where(x => x.ModuleId == m.Id.ToGuid()).ToList();
                }
                List<ModuleOperateResponse> list = new List<ModuleOperateResponse>();
                Utils.CreateTree(null, dtos, list);
                return list;
            }
        }
        /// <summary>
        /// 根据用户Id获取授权的菜单操作列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<ModuleOperateResponse>> GetAuthorizeModuleOperates(Guid userId)
        {
            using (var db = base.NewDB())
            {
                List<Module> modules = null;
                List<Operate> operates = null;
                //如果是管理员
                if (userId == AppSetting.SystemConfig.Admin.ToGuid())
                {
                    //取出所有模块所有操作
                    modules = await db.Module.AsNoTracking().OrderBy(o => o.Sort).ToListAsync();
                    operates = await db.Operate.AsNoTracking().ToListAsync();
                }
                else
                {
                    Guid[] roleIdList = db.Role.WhereByUserId(userId).Select(s => s.Id).ToArray();
                    List<Privilege> privilegeList = await db.Privilege.Get(MasterEnum.Role, roleIdList).ToListAsync();
                    Guid[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                    Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                    modules = await db.Module.Where(x => moduleIds.Contains(x.Id)).OrderBy(o => o.Sort).ToListAsync();
                    operates = await db.Operate.Where(x => operateIds.Contains(x.Id)).ToListAsync();
                }
                var operateDtos = _mapper.Map<List<OperateResponse>>(operates);
                var moduleDtos = _mapper.Map<List<ModuleOperateResponse>>(modules);
                foreach (var m in moduleDtos)
                {
                    m.Operates = operateDtos.Where(x => x.ModuleId == m.Id.ToGuid()).ToList();
                }
                List<ModuleOperateResponse> list = new List<ModuleOperateResponse>();
                Utils.CreateTree(null, moduleDtos, list);
                return list;
            }
        }
        /// <summary>
        /// 获取授权的模块操作Id列表
        /// </summary>
        /// <param name="master"></param>
        /// <param name="masterValue"></param>
        /// <returns></returns>
        public async Task<AuthorizeModuleOperateIdsResponse> GetAuthorizeModuleOperateIds(MasterEnum master, Guid masterValue)
        {
            using (var db = NewDB())
            {
                AuthorizeModuleOperateIdsResponse response = new AuthorizeModuleOperateIdsResponse();
                response.ModuleIds = await db.Privilege.Get(master, AccessEnum.Module, masterValue).Select(s => s.AccessValue).ToListAsync();
                response.OperateIds = await db.Privilege.Get(master, AccessEnum.Operate, masterValue).Select(s => s.AccessValue).ToListAsync();
                return response;
            }
        }
    }
}
