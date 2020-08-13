using Jyz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public interface IPrivilegeService
    {
        List<PrivilegeResponse> GetPrivilegeByUserId(Guid userId);
        /// <summary>
        ///  获取模块树及权限
        /// </summary>
        /// <param name="master"></param>
        /// <param name="masterValue"></param>
        /// <returns></returns>
        Task<ModuleAndPrivilegeResponse> GetModuleAndPrivilege(MasterEnum master, Guid masterValue);
    }
}
