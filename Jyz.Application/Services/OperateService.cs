using Jyz.Application.Interfaces;
using Jyz.Domain;
using Jyz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jyz.Application.Services
{
    public class OperateService : BaseService, IOperateService
    {
        /// <summary>
        /// 根据privilegeIds获取操作列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        public List<Operate> GetListByPrivilegeIds(List<Guid> privilegeIds)
        {
            using (var db = NewDB())
            {
                var moduleIds = db.Privilege.Where(x => privilegeIds.Contains(x.Id) && x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                List<Operate> operates = db.Operate.Where(x => moduleIds.Contains(x.Id)).ToList();
                return operates;
            }
        }
    }
}
