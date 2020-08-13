using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class DepartmentModifyRequest : DepartmentAddRequest
    {
        public Guid Id { get; set; }
    }
}
