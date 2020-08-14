using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using System;
using System.Threading.Tasks;

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
        protected void BeforeAdd<T>(T t) where T : ICreateEntity<Guid>
        {
            t.CreatedBy = CurrentUser.UserId;
            t.CreatedByName = CurrentUser.UserName;
            t.CreatedOn = DateTime.Now;
        }
        protected void BeforeModify<T>(T t) where T : IUpdateEntity<Guid>
        {
            t.UpdatedBy = CurrentUser.UserId;
            t.UpdatedByName = CurrentUser.UserName;
            t.UpdatedOn = DateTime.Now;
        }
    }
}
