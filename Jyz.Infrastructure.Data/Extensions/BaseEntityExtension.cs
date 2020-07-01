using Jyz.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class BaseEntityExtension
    {
        public static T Get<T>(this IQueryable<T> query, Guid id) where T : Entity<Guid>
        {
            return query.FirstOrDefault(x => x.Id == id);
        }
        public static IQueryable<T> Where<T>(this IQueryable<T> query, IEnumerable<Guid> ids) where T : Entity<Guid>
        {
            return query.Where(x => ids.Contains(x.Id));
        }
    }
}
