using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class UserModifyRequest:UserAddRequest
    {
        public Guid Id { get; set; }
    }
}
