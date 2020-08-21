using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class OperateUrlResponse
    {
        public Guid ModuleId { get; set; }
        public string Controller { get; set; }
        public Guid OperateId { get; set; }
        public string Action { get; set; }
        public bool IsAuthorize { get; set; } = false;
    }
}
