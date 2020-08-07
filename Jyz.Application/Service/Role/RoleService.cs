using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Data;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;

namespace Jyz.Application
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IMapper _mapper;
        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 根据id获取role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RoleResponse> Detail(Guid id)
        {
            using (var db = NewDB())
            {
                var model = await db.Role.FindByIdAsync(id);
                return _mapper.Map<RoleResponse>(model);
            }
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<PageResponse<RoleResponse>> Query(PageRequest info)
        {
            using (var db = NewDB())
            {
                PageResponse<RoleResponse> model = new PageResponse<RoleResponse>();
                int totalCount = await db.User.CountAsync();
                List<Role> list = await db.Role.Paging(info.PageIndex, info.PageSize).ToListAsync();
                model.PageIndex = info.PageIndex;
                model.PageSize = info.PageSize;
                model.TotalCount = totalCount;
                model.List = _mapper.Map<List<RoleResponse>>(list);
                return model;
            }
        }
        /// <summary>
        /// 根据用户Id获取角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<RoleResponse>> GetUserRoles(Guid userId)
        {
            using (var db = NewDB())
            {
                var roles = await (from a in db.Role
                                   join b in db.Role_User on a.Id equals b.RoleId
                                   where b.UserId == userId
                                   select a).ToListAsync();
                return _mapper.Map<List<RoleResponse>>(roles);
            }
        }
        /// <summary>
        /// 角色信息修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Save(RoleRequest info)
        {
            using (var db = NewDB())
            {
                if (info.RoleId != null)
                {
                    await db.ExecSqlNoQuery("delete Role_User", new SqlParameter("RoleId", info.RoleId));
                    await db.ExecSqlNoQuery("delete Privilege", new SqlParameter("MasterValue", info.RoleId));
                    Role role = await db.Role.FindByIdAsync(info.RoleId);
                    _mapper.Map(info.Role, role);
                    BeforeAddOrModify(role);
                }
                else
                {
                    Role role = _mapper.Map<Role>(info.Role);
                    await db.AddAsync(role);
                    await db.SaveChangesAsync();
                    info.RoleId = role.Id;
                }
                foreach (Guid id in info.ModuleIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Role, info.RoleId, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Role, info.RoleId, AccessEnum.Operate, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.UserIds)
                {
                    Role_User model = new Role_User();
                    model.UserId = id;
                    model.RoleId = info.RoleId;
                    await db.AddAsync(model);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
