﻿using Jyz.Infrastructure;
using System;
using System.Collections.Generic;

namespace Jyz.Application
{
    public class ModuleResponse : BaseResponse,ITreeNode<ModuleResponse>
    {
        public object Id { get; set; }
        public object PId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
        public List<ModuleResponse> Children { get; set; } = new List<ModuleResponse>();
    }
}
