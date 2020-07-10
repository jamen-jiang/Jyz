using Jyz.Application.Dtos;
using Jyz.Application.Exception;
using Jyz.Application.Interfaces;
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
    }
}
