using Jyz.Application.Interfaces;
using Jyz.Application.ViewModels;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Data.Extensions;
using Jyz.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Jyz.Application.Services
{
    public class ModuleService : BaseService, IModuleService
    {
        
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
