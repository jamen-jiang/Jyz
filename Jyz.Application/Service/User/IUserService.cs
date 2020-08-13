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
        Task<PageResponse<UserResponse>> Query(PageRequest<UserRequest> info);
        /// <summary>
        /// 根据角色Id获取用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetRoleUsers(Guid roleId);
        /// <summary>
        /// 根据id获取user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponse> Detail(Guid id);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task Add(UserAddRequest info);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task Modify(UserModifyRequest info);
    }
}
