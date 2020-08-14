using Jyz.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class ModuleOperateResponse: ModuleResponse, ITreeNode<ModuleOperateResponse>
    {
        public List<OperateResponse> Operates { get; set; } = new List<OperateResponse>();
        public new List<ModuleOperateResponse> Children { get; set; } = new List<ModuleOperateResponse>();
    }
}
