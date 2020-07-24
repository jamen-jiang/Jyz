using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
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
                var moduleIds = db.Privilege.Where(x => privilegeIds.Contains(x.Id) && x.Access == AccessEnum.Module.ToString()).Select(s=>s.AccessValue).ToArray();
                List<Module> modules = db.Module.WhereByModuleIds(moduleIds).ToList();
                return modules;
            }
        }
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="isEnable">是否包含软删除(默认不包含)</param>
        /// <returns></returns>
        public async Task<List<ModuleResponse>> Get(bool isEnable = false)
        {
            using (var db = NewDB())
            {
                var query = db.Module.AsNoTracking();
                if (isEnable)
                    query = query.IgnoreQueryFilters();
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
        private void CreateModuleTree(ModuleResponse node, List<ModuleResponse> dtos)
        {
            var childs = dtos.Where(x => x.PId == node.Id).ToList();
            foreach (var c in childs)
            {
                node.Children.Add(c);
                CreateModuleTree(c, dtos);
            }
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        public void Add()
        {
            //using (var db = base.NewDB())
            //{
            //    if (db.Module.IsExist(obj.Name))
            //        throw new ApplicationException("模块名称已存在!");
            //    Module module = new Module();
            //    module.Name = obj.Name;
            //    module.IsEnable = true;
            //    module.Remark = obj.Remark;
            //    module.Sort = obj.Sort;
            //    module.Icon = obj.Icon;
            //    module.CreatedBy = obj.UserId;
            //    module.CreatedOn = DateTime.Now;
            //    db.Module.Add(module);
            //    db.SaveChanges();
            //}
        }
    }
}
