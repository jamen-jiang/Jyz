using Jyz.Domain;
using Jyz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class PrivilegeExtension
    {
        /// <summary>
        /// 根据权限对象(Master)获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master"></param>
        /// <param name="masterValues"></param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum master, params Guid [] masterValues)
        {
             return query.Where(x => x.Master == master.ToString() && masterValues.Contains(x.MasterValue));
        }
        /// <summary>
        /// 根据权限对象(Master)及功能对象(Access)获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum master, AccessEnum access, params Guid[] masterValues)
        {
            return query.Where(x => x.Master == master.ToString() && x.Access == access.ToString() && masterValues.Contains(x.MasterValue));
        }
        /// <summary>
        /// 获取已有权限
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <param name="organizationId"></param>
        /// <param name="userRoleIds"></param>
        /// <param name="organizationRoleIds"></param>
        /// <returns></returns>
        public static IQueryable<Privilege> GetByMasterValues(this IQueryable<Privilege> query, Guid userId, Guid organizationId, Guid[] userRoleIds, Guid[] organizationRoleIds)
        {
            var obj = from a in query
            where (a.Master == MasterEnum.User.ToString() && userId == a.MasterValue)
            || (a.Master == MasterEnum.User.ToString() && organizationId == a.MasterValue)
            || (a.Master == MasterEnum.Role.ToString() && userRoleIds.Contains(a.MasterValue))
            || (a.Master == MasterEnum.Organization.ToString() && organizationRoleIds.Contains(a.MasterValue))
            select a;
            return obj.Distinct();
        }
    }
}
