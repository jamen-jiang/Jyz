using Jyz.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Dtos
{
    public class OperateResDto : BaseResDto
    {
        public Guid ModuleId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
