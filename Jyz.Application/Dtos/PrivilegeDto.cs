using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Dtos
{
    public class PrivilegeDto
    {
        public Guid ModuleId { get; set; }
        public string Controller { get; set; }
        public Guid OperateId { get; set; }
        public string Action { get; set; }
    }
}
