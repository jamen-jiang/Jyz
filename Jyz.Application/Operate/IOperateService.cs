using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public interface IOperateService
    {
        /// <summary>
        /// 根据privilegeIds获取操作列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        List<Operate> GetListByPrivilegeIds(List<Guid> privilegeIds);
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        Task<List<OperateResponse>> Get(Guid moduleId);
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<OperateResponse> Detail(Guid id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task Add(OperateRequest info);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        Task Modify(OperateRequest info);
    }
}
