using Jyz.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class BaseEntityExtension
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Get<T>(this IQueryable<T> query, Guid id) where T : Entity<Guid>
        {
            return query.FirstOrDefault(x => x.Id == id && x.IsEnable);
        }
        /// <summary>
        /// IsEnable为true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> Query<T>(this IQueryable<T> query) where T : Entity<Guid>
        {
            return query.Where(x => x.IsEnable);
        }
        /// <summary>
        /// Where入口(IsEnable为true)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static IQueryable<T> Query<T>(this IQueryable<T> query,Expression<Func<T,bool>> lambda) where T : Entity<Guid>
        {
            return query.Where(x => x.IsEnable).Where(lambda);
        }
    }
}
