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
using System.Text;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public class DepartmentService : BaseService,IDepartmentService
    {
        private readonly IMapper _mapper;
        public DepartmentService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<List<DepartmentResponse>> Query(DepartmentRequest info)
        {
            using (var db = NewDB())
            {
                var query = db.Department.AsNoTracking();
                if (!info.Name.IsNullOrEmpty())
                    query = query.Where(x => x.Name.Contains(info.Name));
                List<Department> departments = await query.ToListAsync();
                var dtos = _mapper.Map<List<DepartmentResponse>>(departments);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var list = new List<DepartmentResponse>();
                foreach (DepartmentResponse p in pDtos)
                {
                    list.Add(p);
                    CreateDepartmentTree(p, dtos);
                }
                return list;
            }
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DepartmentResponse> Detail(Guid id)
        {
            using (var db = NewDB())
            {
                var department = await db.Department.FindByIdAsync(id);
                return _mapper.Map<DepartmentResponse>(department);
            }
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComboBoxTreeResponse>> GetDepartments()
        {
            using (var db = NewDB())
            {
                var departments = await db.Department.AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<ComboBoxTreeResponse>>(departments);
                var pDtos = dtos.Where(x => x.PId == null).ToList();
                var list = new List<ComboBoxTreeResponse>();
                foreach (var p in pDtos)
                {
                    list.Add(p);
                    CreateTree(p, dtos);
                }
                return list;
            }
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Add(DepartmentAddRequest info)
        {
            using (var db = NewDB())
            {
                Department department = _mapper.Map<Department>(info.Department);
                BeforeAddOrModify(department);
                await db.Department.AddAsync(department);
                await db.SaveChangesAsync();
                foreach (Guid id in info.ModuleIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Department, department.Id, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Department, department.Id, AccessEnum.Operate, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.RoleIds)
                {
                    Role_Department model = new Role_Department();
                    model.DepartmentId = department.Id;
                    model.RoleId = id;
                    await db.AddAsync(model);
                }
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Modify(DepartmentModifyRequest info)
        {
            using (var db = NewDB())
            {
                await db.ExecSqlNoQuery("delete Role_Department where DepartmentId=@DepartmentId", new SqlParameter("DepartmentId", info.Id));
                await db.ExecSqlNoQuery("delete Privilege where MasterValue=@MasterValue", new SqlParameter("MasterValue", info.Id));
                var department = await db.Department.FindByIdAsync(info.Id);
                _mapper.Map(info.Department, department);
                BeforeAddOrModify(department);
                foreach (Guid id in info.ModuleIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Department, info.Id, AccessEnum.Module, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.OperateIds)
                {
                    Privilege privilege = new Privilege(MasterEnum.Department, info.Id, AccessEnum.Operate, id);
                    await db.AddAsync(privilege);
                }
                foreach (Guid id in info.RoleIds)
                {
                    Role_Department model = new Role_Department();
                    model.DepartmentId = info.Id;
                    model.RoleId = id;
                    await db.AddAsync(model);
                }
                await db.SaveChangesAsync();
            }
        }
        private void CreateTree(ComboBoxTreeResponse node, List<ComboBoxTreeResponse> dtos)
        {
            var childs = dtos.Where(x => x.PId.ToGuid() == node.Id.ToGuid()).ToList();
            foreach (var c in childs)
            {
                node.Children.Add(c);
                CreateTree(c, dtos);
            }
        }
        /// <summary>
        /// 获取当前部门及下面所有部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetCurrentAndChildrenIdList(Guid id)
        {
            using (var db = NewDB())
            {
                var departments = await db.Department.AsNoTracking().ToListAsync();
                List<Guid> idList = new List<Guid>();
                idList.Add(id);
                GetChildrenDepartmentIdList(departments, idList, id);
                return idList;
            }
        }
        /// <summary>
        /// 获取当前部门及下面所有部门
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="idList"></param>
        /// <param name="id"></param>
        private void GetChildrenDepartmentIdList(List<Department> departments, List<Guid> idList, Guid departmentId)
        {
            var childrens = departments.Where(x => x.PId == departmentId).Select(s=>s.Id).ToList();
            if (childrens.Count > 0)
            {
                idList.AddRange(childrens);
                foreach (Guid id in childrens)
                {
                    GetChildrenDepartmentIdList(departments, idList, id);
                }
            }
        }
        private void CreateDepartmentTree(DepartmentResponse node, List<DepartmentResponse> dtos)
        {
            var childs = dtos.Where(x => x.PId == node.Id).ToList();
            foreach (var c in childs)
            {
                node.Children.Add(c);
                CreateDepartmentTree(c, dtos);
            }
        }
    }
}
