using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public async Task<PageResponse<UserResponse>> Query(PageRequest<UserQuery> info)
        {
            using (var db = NewDB())
            {
                PageResponse<UserResponse> model = new PageResponse<UserResponse>();
                var query = db.User.AsNoTracking();

                if (!info.Query.Name.IsNullOrEmpty())
                    query = query.Where(x => x.Name.Contains(info.Query.Name));
                if (!info.Query.UserName.IsNullOrEmpty())
                    query = query.Where(x => x.UserName.Contains(info.Query.UserName));
                if (info.Query.CreatedOnStart!=null)
                    query = query.Where(x => x.CreatedOn >= info.Query.CreatedOnStart);
                if (info.Query.CreatedOnEnd != null)
                    query = query.Where(x => x.CreatedOn <= info.Query.CreatedOnEnd);

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
        /// <summary>
        /// 根据id获取user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponse> Detail(Guid id)
        {
            using (var db = NewDB())
            {
                var model = await db.User.FindByIdAsync(id);
                return _mapper.Map<UserResponse>(model);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Add(UserAddRequest info)
        {
            using (var db = NewDB())
            {
                User user = _mapper.Map<User>(info);
                BeforeAddOrModify(user);
                //密码暂写死
                user.PassWord = user.UserName;
                await db.User.AddAsync(user);
                await db.SaveChangesAsync();
                foreach (Guid id in info.ModuleIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Role, user.Id, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Role, user.Id, AccessEnum.Operate, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.RoleIds)
                {
                    Role_User model = new Role_User();
                    model.UserId = user.Id;
                    model.RoleId = id;
                    await db.AddAsync(model);
                }
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Modify(UserModifyRequest info)
        {
            using (var db = NewDB())
            {
                await db.ExecSqlNoQuery("delete Role_User", new SqlParameter("UserId",info.Id));
                await db.ExecSqlNoQuery("delete Privilege", new SqlParameter("MasterValue", info.Id));
                var user = await db.User.FindByIdAsync(info.Id);
                _mapper.Map(info.User, user);
                BeforeAddOrModify(user);
                foreach (Guid id in info.ModuleIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.User, info.Id, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.User, info.Id, AccessEnum.Operate, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.RoleIds)
                {
                    Role_User model = new Role_User();
                    model.UserId = info.Id;
                    model.RoleId = id;
                    await db.AddAsync(model);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
