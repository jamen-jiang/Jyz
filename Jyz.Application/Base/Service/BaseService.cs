﻿using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using System;

namespace Jyz.Application
{
    public abstract class BaseService
    {
        protected JyzContext NewDB()
        {
            return new JyzContext();
        }
        /// <summary>
        /// 添加或修改实体前
        /// 添加(创建人赋值)
        /// 修改(修改人及修改时间赋值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        protected void BeforeAddOrModify<T>(T t) where T : Entity<Guid>
        {
            if (t.Id.IsEmpty())
            {
                t.CreatedBy = UserContext.UserId;
                t.CreatedByName = UserContext.UserName;
            }
            else
            {
                t.UpdatedBy = UserContext.UserId;
                t.UpdatedByName = UserContext.UserName;
                t.UpdatedOn = DateTime.Now;
            }
        }
    }
}