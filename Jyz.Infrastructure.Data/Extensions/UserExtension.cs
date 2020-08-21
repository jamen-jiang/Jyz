using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class UserExtension
    {
        public static IQueryable<User> GetByOrganizationIds(this IQueryable<User> query, Guid [] organizationIds)
        {
            var obj = from a in query
                      from b in a.Organization_User
                      where  organizationIds.Contains(b.OrganizationId)
                      select a;
            return obj.Distinct();
        }
    }
}
