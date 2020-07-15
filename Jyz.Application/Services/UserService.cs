using AutoMapper;
using Jyz.Application.Dtos;
using Jyz.Application.Exception;
using Jyz.Application.Interfaces;
using Jyz.Application.Response;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Domain.Models;
using Jyz.Infrastructure.Data.Extensions;
using Jyz.Infrastructure.Extensions;
using Jyz.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class UserService : BaseService,IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 登录(返回token)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<LoginResDto> Login(LoginReqDto info)
        {
            using (var db = base.NewDB())
            {
                User user =  await db.User.FirstOrDefaultAsync(x => x.UserName == info.UserName && x.PassWord == info.PassWord);
                if (user == null)
                    throw new ApiException("用户名或密码错误!");
                //角色Id列表
                Guid[] roleIds= db.Role.WhereByUserId(user.Id).Select(s => s.Id).ToArray();
                Token ts = new Token();
                ts.UserId = user.Id;
                string token = JwtUtil.SetJwtEncode(ts);
                LoginResDto response = new LoginResDto();
                response.Name = user.Name;
                response.Token = token;
                return response;
            }
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Get(int pageIndex = 1, int pageSize = 10)
        {
            using (var db = NewDB())
            {
                ApiResponse response = new ApiResponse();
                int totalCount = await db.User.CountAsync();
                List<User> list = await db.User.Paging(pageIndex, pageSize).ToListAsync();
                var data = _mapper.Map<List<UserResDto>>(list);
                response.PageIndex = pageIndex;
                response.PageSize = pageSize;
                response.TotalCount = totalCount;
                response.Data = data;
                return response;
            }
        }
    }
}
