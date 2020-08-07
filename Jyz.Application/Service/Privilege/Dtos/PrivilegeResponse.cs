using System;

namespace Jyz.Application
{
    public class PrivilegeResponse
    {
        public Guid ModuleId { get; set; }
        public string Controller { get; set; }
        public Guid OperateId { get; set; }
        public string Action { get; set; }
    }
}
