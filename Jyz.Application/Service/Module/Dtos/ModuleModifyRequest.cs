using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class ModuleModifyRequest : ModuleAddRequest
    {
        public Guid Id { get; set; }
    }
}
