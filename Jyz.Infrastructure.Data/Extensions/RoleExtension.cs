using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class RoleExtension
    {
        /// <summary>
        /// 根据用户Id获取Role的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IQueryable<Role> GetByUserId(this IQueryable<Role> query, Guid userId)
        {
            var obj = from a in query
                      from b in a.Role_User
                      where b.UserId == userId
                      select a;
            return obj.Distinct();
        }
        public static IQueryable<Role> GetByOrganizationIds(this IQueryable<Role> query, Guid [] organizationIds)
        {
            var obj = from a in query
                      from b in a.Role_Organization
                      where  organizationIds.Contains(b.OrganizationId)
                      select a;
            return obj.Distinct();
        }
    }
}
