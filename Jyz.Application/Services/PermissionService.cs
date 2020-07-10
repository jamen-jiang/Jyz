using AutoMapper;
using Jyz.Application.Dtos;
using Jyz.Application.Interfaces;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application.Services
{
    public class PermissionService : BaseService, IPermissionService
    {
        private readonly IMapper _mapper;
        public PermissionService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 获取全部权限
        /// </summary>
        /// <returns></returns>
        public async Task<List<PrivilegeDto>> GetAllPermission()
        {
            using (var db = NewDB())
            {
                List<PrivilegeDto> list =
                   await (from a in db.Privilege
                          join b in db.Module on new { a.Access, a.AccessValue } equals new { Access = AccessEnum.Module.ToString(), AccessValue = b.Id }
                          join c in db.Operate on new { a.Access, a.AccessValue, ModuleId = b.Id } equals new { Access = AccessEnum.Operate.ToString(), AccessValue = c.Id, c.ModuleId }
                          where b.IsEnable && c.IsEnable
                          select new PrivilegeDto
                          {
                              ModuleId = b.Id,
                              Controller = b.Controller,
                              OperateId = c.Id,
                              Action = c.Action
                          }).ToListAsync();
                return list;
            }
        }
    }
}
