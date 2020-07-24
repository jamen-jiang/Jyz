using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public  interface IUserService
    {
        /// <summary>
        /// 登录(返回token)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<LoginResponse> Login(LoginRequest info);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<PageResDto<UserResponse>> Get(PageReqDto info);
        /// <summary>
        /// 根据角色Id获取用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetRoleUsers(Guid roleId);
    }
}
