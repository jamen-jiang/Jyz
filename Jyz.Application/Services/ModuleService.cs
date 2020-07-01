using Jyz.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Jyz.Application.Services
{
    public class ModuleService : BaseService
    {
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
