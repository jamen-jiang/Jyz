using Jyz.Application.Dtos;
using Jyz.Application.Exception;
using Jyz.Application.Interfaces;
using Jyz.Application.Jwt;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Data.Extensions;
using Jyz.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<string> Login(LoginInfo info)
        {
            using (var db = base.NewDB())
            {
                User user =  await db.User.FirstOrDefaultAsync(x => x.UserName == info.UserName && x.PassWord == info.PassWord);
                if (user == null)
                    throw new ApiException("用户名或密码错误!");
                List<Operate> operateList = null;
                if (user.Id == "844C3BA5-3065-4D77-AE60-DEAD1B5BEFD6".ToGuid())
                {
                    operateList = db.Operate.ToList();
                }
                else
                {
                    Guid[] roleIdList = db.Role.GetRoleIdList(user.Id).ToArray();
                    List<Privilege> privilegeList = db.Privilege.Get(MasterEnum.Role, null, roleIdList).ToList();
                    Guid[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                    operateList = db.Operate.Where(x => operateIds.Contains(x.Id)).ToList();
                }
                Token ts = new Token(user.Id, operateList);
                Payload payload = new Payload(ts);
                //string token = JwtUtils.SetJwtEncode(payload);
                //return token;
                return "";
            }
        }
    }
}
