using Jyz.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Dtos
{
    public class UserResDto : BaseResDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
