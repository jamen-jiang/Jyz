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
        public async Task<PageResDto<RoleResponse>> Get(PageReqDto info)
        {
            using (var db = NewDB())
            {
                PageResDto<RoleResponse> model = new PageResDto<RoleResponse>();
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
                    await db.ExecSqlNoQuery("delete Role_User");
                    await db.ExecSqlNoQuery("delete Privilege");
                    Role role = await db.Role.FindByIdAsync(info.RoleId);
                    _mapper.Map(info.Role, role);
                    base.BeforeAddOrModify(role);
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
                    Privilege privilege = AddPrivilege(MasterEnum.Role, info.RoleId, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = AddPrivilege(MasterEnum.Role, info.RoleId, AccessEnum.Operate, id);
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
        private Privilege AddPrivilege(MasterEnum master,Guid masterValue,AccessEnum access,Guid accessValue)
        {
            Privilege privilege = new Privilege();
            privilege.Master = master.ToString();
            privilege.MasterValue = masterValue;
            privilege.Access = access.ToString();
            privilege.AccessValue = accessValue;
            return privilege;
        }
    }
}
