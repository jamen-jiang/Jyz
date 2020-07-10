﻿using Jyz.Domain;
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
        /// <param name="masterValue"></param>
        /// <returns></returns>
        public static IQueryable<Privilege> WhereByMaster(this IQueryable<Privilege> query, MasterEnum master, params Guid [] masterValue)
        {
             return query.Where(x => x.Master == master.ToString() && masterValue.Contains(x.MasterValue));
        }


        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <param name="accessValues">领域对象Id</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access, Guid [] masterValues, params Guid[]  accessValues)
        {
            if (master != null)
                query = query.Where(w => w.Master == master.ToString());
            if (masterValues != null)
                query = query.Where(w => masterValues.Contains(w.MasterValue));
            if (access != null)
                query = query.Where(w => w.Access == access.ToString());
            if (accessValues != null)
                query = query.Where(w => accessValues.Contains(w.AccessValue));
            return query.Distinct();
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access, params Guid[] masterValues)
        {
            return Get(query, master, access, masterValues, null);
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access)
        {
            return Get(query, master, access, null, null);
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master)
        {
            return Get(query, master, null, null, null);
        }
        /// <summary>
        /// 获取AccessValue的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <returns></returns>
        public static List<Guid> GetAccessValueList(this IQueryable<Privilege> query, MasterEnum master, AccessEnum access, params Guid[] masterValues)
        {
            return Get(query, master, access, masterValues).Select(s => s.AccessValue).ToList();
        }
        /// <summary>
        /// 获取AccessValue的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="masterValue">主体对象Id</param>
        /// <returns></returns>
        public static List<Privilege> GetPrivilegeList(this IQueryable<Privilege> query, MasterEnum ? master, params Guid[] masterValues)
        {
            return Get(query, master, null, masterValues).Distinct().ToList();
        }
    }
}
