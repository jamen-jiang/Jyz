using Jyz.Application.Dtos;
using Jyz.Application.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Application.Interfaces
{
    public  interface IUserService
    {
        /// <summary>
        /// 登录(返回token)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<LoginResDto> Login(LoginReqDto info);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<ApiResponse> Get(int pageIndex = 1, int pageSize = 10);
    }
}
