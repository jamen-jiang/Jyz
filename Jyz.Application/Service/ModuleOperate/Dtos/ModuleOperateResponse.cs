using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class ModuleOperateResponse: ModuleResponse
    {
        public List<OperateResponse> Operates { get; set; } = new List<OperateResponse>();
    }
}
