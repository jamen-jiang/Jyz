﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class AuthorizeModuleOperateIdsResponse
    {
        public List<Guid> ModuleIds { get; set; } = new List<Guid>();
        public List<Guid> OperateIds { get; set; } = new List<Guid>();
    }
}
