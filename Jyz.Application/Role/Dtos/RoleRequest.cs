using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class RoleRequest
    {
        public RoleModel Role { get; set; }
        public Guid RoleId { get; set; }
        public List<Guid> UserIds { get; set; }
        public List<Guid> ModuleIds { get; set; }
        public List<Guid> OperateIds { get; set; }
    }
    public class RoleModel
    {
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
