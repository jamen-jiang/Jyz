using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Infrastructure.Data
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
        public static T FindById<T>(this IQueryable<T> query, Guid id) where T : Entity<Guid>
        {
            return  query.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// 获取全部忽视isEnable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> GetAll<T>(this IQueryable<T> query) where T : Entity<Guid>
        {
            return query.IgnoreQueryFilters();
        }
        /// <summary>
        /// 根据Id获取实体(异步)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async  Task<T> FindByIdAsync<T>(this IQueryable<T> query, Guid id) where T : Entity<Guid>
        {
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> Paging<T>(this IQueryable<T> query,  int pageIndex, int pageSize) where T : Entity<Guid>
        {
            return query.Skip( pageSize * (pageIndex - 1)).Take(pageSize);
        }
    }
}
