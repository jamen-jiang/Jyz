using AutoMapper;
using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public async Task<LoginResponse> Login(LoginRequest info)
        {
            using (var db = base.NewDB())
            {
                User user =  await db.User.FirstOrDefaultAsync(x => x.UserName == info.UserName && x.PassWord == info.PassWord);
                if (user == null)
                    throw new ApiException("用户名或密码错误!");
                Token ts = new Token();
                ts.UserId = user.Id;
                ts.UserName = user.Name;
                string token = JwtUtil.SetJwtEncode(ts);
                LoginResponse response = new LoginResponse();
                response.Name = user.Name;
                response.Token = token;
                return response;
            }
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public async Task<PageResDto<UserResponse>> Get(PageReqDto info)
        {
            using (var db = NewDB())
            {
                PageResDto<UserResponse> model = new PageResDto<UserResponse>();
                var query = db.User.AsNoTracking();
                int totalCount = await query.CountAsync();
                List<User> list = await query.Paging(info.PageIndex, info.PageSize).ToListAsync();
                model.PageIndex = info.PageIndex;
                model.PageSize = info.PageSize;
                model.TotalCount = totalCount;
                model.List = _mapper.Map<List<UserResponse>>(list); ;
                return model;
            }
        }
        /// <summary>
        /// 根据角色Id获取用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<UserResponse>> GetRoleUsers(Guid roleId)
        {
            using (var db = NewDB())
            {
                var users = await (from a in db.User
                                   join b in db.Role_User on a.Id equals b.UserId
                                   where b.RoleId == roleId
                                   select a).ToListAsync();
                return _mapper.Map<List<UserResponse>>(users);
            }
        }
    }
}
