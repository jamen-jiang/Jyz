using Jyz.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jyz.Application.Interfaces
{
    public interface IPermissionService
    {
        /// <summary>
        /// 获取全部权限
        /// </summary>
        /// <returns></returns>
        Task<List<PrivilegeDto>> GetAllPermission();
    }
}
