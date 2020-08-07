using Jyz.Infrastructure;
using System;
using System.Collections.Generic;

namespace Jyz.Application
{
    public class ModuleRequest 
    {
        public Guid Id { get; set; }
        public Guid? PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
    }
}
