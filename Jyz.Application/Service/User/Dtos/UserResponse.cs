using System;
using System.Collections.Generic;

namespace Jyz.Application
{
    public class UserResponse: BaseResponse
    {
        public Guid Id { get; set; }
        public List<Guid> OrganizationIds { get; set; } = new List<Guid>();
        public List<string> OrganizationNames { get; set; } = new List<string>();
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Remark { get; set; }
    }
}
