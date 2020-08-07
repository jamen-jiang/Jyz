using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class OperateService : BaseService, IOperateService
    {
        private readonly IMapper _mapper;
        public OperateService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 根据privilegeIds获取操作列表
        /// </summary>
        /// <param name="privilegeIds"></param>
        /// <returns></returns>
        public List<Operate> GetListByPrivilegeIds(List<Guid> privilegeIds)
        {
            using (var db = NewDB())
            {
                var moduleIds = db.Privilege.Where(x => privilegeIds.Contains(x.Id) && x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                List<Operate> operates = db.Operate.Where(x => moduleIds.Contains(x.Id)).ToList();
                return operates;
            }
        }
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async  Task<List<OperateResponse>> Query(Guid moduleId)
        {
            using (var db = NewDB())
            {
                var operates = await db.Operate.AsNoTracking().Where(x => x.ModuleId == moduleId).ToListAsync();
                return _mapper.Map<List<OperateResponse>>(operates);
            }
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OperateResponse> Detail(Guid id)
        {
            using (var db = NewDB())
            {
                Operate operate = await db.Operate.FindByIdAsync(id);
                return _mapper.Map<OperateResponse>(operate);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Add(OperateRequest info)
        {
            using (var db = NewDB())
            { 
                Operate model = _mapper.Map<Operate>(info);
                BeforeAddOrModify(model);
                await db.Operate.AddAsync(model);
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        public async Task Modify(OperateRequest info)
        {
            using (var db = NewDB())
            {
                Operate model = await db.Operate.FindByIdAsync(info.Id);
                _mapper.Map(info,model);
                BeforeAddOrModify(model);
                await db.SaveChangesAsync();
            }
        }
    }
}
