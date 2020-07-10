using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Interfaces
{
    public interface IOperateService
    {
        /// <summary>
        /// 根据privilegeIds获取操作列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        List<Operate> GetListByPrivilegeIds(List<Guid> privilegeIds);
    }
}
