using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class DepartmentAddRequest
    {
        public DepartmentInfo Department { get; set; }
        public List<Guid> RoleIds { get; set; }
        public List<Guid> ModuleIds { get; set; }
        public List<Guid> OperateIds { get; set; }
    }
    public class DepartmentInfo
    {
        public Guid? PId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
