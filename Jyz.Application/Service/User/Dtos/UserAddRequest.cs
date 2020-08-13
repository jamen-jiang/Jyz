using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class UserAddRequest
    {
        public UserInfo User { get; set; }
        public List<Guid> RoleIds { get; set; }
        public List<Guid> ModuleIds { get; set; }
        public List<Guid> OperateIds { get; set; }
    }
    public class UserInfo
    {
        public Guid DepartmentId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
