using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class OperateRequest
    {
        public Guid ModuleId { get; set; }
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Remark { get; set; }
    }
}
